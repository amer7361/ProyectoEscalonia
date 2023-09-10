using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class Role
{
    public int idRol { get; set; }

    public string rol { get; set; } = null!;

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
