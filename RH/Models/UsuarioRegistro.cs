using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class UsuarioRegistro
{
    public int? IdUser { get; set; }

    public int? IdR { get; set; }

    public virtual Registro? IdRNavigation { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
