using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Registro
{
    public int IdRegistro { get; set; }

    public int? IdUser { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public DateTime? FechaSalida { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
