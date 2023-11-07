using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public int IdEstado { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Solicitud { get; set; } = null!;

    public DateTime FechaSolicfitud { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public virtual Estado IdEstadoNavigation { get; set; } = null!;
}
