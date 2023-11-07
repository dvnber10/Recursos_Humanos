using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Nomina
{
    public int IdNomina { get; set; }

    public int? IdUser { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Aumento { get; set; }

    public int? CanHoras { get; set; }

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();

    public virtual Usuario? IdUserNavigation { get; set; }
}
