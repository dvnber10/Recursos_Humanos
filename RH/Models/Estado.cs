using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public int? IdNomina { get; set; }

    public string Estado1 { get; set; } = null!;

    public virtual Nomina? IdNominaNavigation { get; set; }

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
