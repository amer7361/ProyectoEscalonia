using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class PermisosRole
{
    public int idPermisosRoles { get; set; }

    public int idRol { get; set; }

    public int idPermiso { get; set; }

    public virtual Permiso idPermisoNavigation { get; set; } = null!;

    public virtual Role idRolNavigation { get; set; } = null!;
}
