using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Afiliacion
{
    public int IdAfiliacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
