using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Contratacion
{
    public int IdContratacion { get; set; }

    public int IdAsp { get; set; }

    public string? Estado { get; set; }

    public virtual Aspirante IdAspNavigation { get; set; } = null!;
}
