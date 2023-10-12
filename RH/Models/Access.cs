using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Access
{
    public int IdPass { get; set; }

    public string Pass { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
