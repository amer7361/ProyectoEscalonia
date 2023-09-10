using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class Permiso
{
    public int idPermiso { get; set; }

    public string nombre { get; set; } = null!;

    public string path { get; set; } = null!;

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();
}
