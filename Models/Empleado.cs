using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class Empleado
{
    public int idEmpleado { get; set; }

    public string nombres { get; set; } = null!;

    public string apellidos { get; set; } = null!;

    public string telefono { get; set; } = null!;

    public string email { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
