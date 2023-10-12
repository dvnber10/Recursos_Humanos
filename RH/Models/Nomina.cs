using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Nomina
{
    public int IdNomina { get; set; }

    public int CantHoras { get; set; }

    public int? Aumento { get; set; }

    public int? Descuento { get; set; }

    public int IdPermisos { get; set; }

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
