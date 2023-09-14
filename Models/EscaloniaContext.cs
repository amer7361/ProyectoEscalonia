using System;
using System.Collections.Generic;
using LaEscalonia.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace LaEscalonia.Models;

public partial class EscaloniaContext : DbContext
{
    public EscaloniaContext()
    {
    }

    public EscaloniaContext(DbContextOptions<EscaloniaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Configuracione> Configuraciones { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosRole> PermisosRoles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<UserRequest> UserRequest { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRequest>(x=>x.HasNoKey());
        modelBuilder.Entity<Configuracione>(entity =>
        {
            entity.HasKey(e => e.idConfiguracion);

            entity.Property(e => e.diaRiego)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.duracionRiegoSeg)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.idUsuarioNavigation).WithMany(p => p.Configuraciones)
                .HasForeignKey(d => d.idUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Configuraciones_Usuarios");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.idEmpleado);

            entity.Property(e => e.apellidos)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.nombres)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.idPermiso);

            entity.Property(e => e.nombre)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.path).IsUnicode(false);
        });

        modelBuilder.Entity<PermisosRole>(entity =>
        {
            entity.HasKey(e => e.idPermisosRoles);

            entity.HasOne(d => d.idPermisoNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.idPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermisosRoles_Permisos");

            entity.HasOne(d => d.idRolNavigation).WithMany(p => p.PermisosRoles)
                .HasForeignKey(d => d.idRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermisosRoles_Roles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.idRol);

            entity.Property(e => e.rol)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.idUsuario);

            entity.Property(e => e.password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.username)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.idEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.idEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Empleados");

            entity.HasOne(d => d.idRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.idRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuarios_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
