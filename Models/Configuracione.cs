using System;
using System.Collections.Generic;

namespace LaEscalonia.Models;

public partial class Configuracione
{
    public int idConfiguracion { get; set; }

    public TimeSpan? horaRiego { get; set; }

    public string? diaRiego { get; set; }

    public string duracionRiegoSeg { get; set; } = null!;

    public int? nivelHumedad { get; set; }

    public int idUsuario { get; set; }

    public virtual Usuario idUsuarioNavigation { get; set; } = null!;
}
