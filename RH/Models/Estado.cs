using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Estado
{
    public int IdEstado { get; set; }

    public string Estado1 { get; set; } = null!;

    public int IdNom { get; set; }

    public int IdPerm { get; set; }

    public virtual Nomina IdNomNavigation { get; set; } = null!;

    public virtual ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();
}
