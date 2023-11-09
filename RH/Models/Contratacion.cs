using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Contratacion
{
    public int IdContratacion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
