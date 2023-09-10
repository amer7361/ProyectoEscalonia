using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class Usuario
{
    public int idUsuario { get; set; }

    public string username { get; set; } = null!;

    public string password { get; set; } = null!;

    public int idRol { get; set; }

    public int idEmpleado { get; set; }

    public virtual ICollection<Configuracione> Configuraciones { get; set; } = new List<Configuracione>();

    public virtual Empleado idEmpleadoNavigation { get; set; } = null!;

    public virtual Role idRolNavigation { get; set; } = null!;
}
