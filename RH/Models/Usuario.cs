using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int Documento { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Telefono { get; set; }

    public string Cargo { get; set; } = null!;

    public int IdRol { get; set; }

    public string Correo { get; set; } = null!;

    public int IdAfiliacion { get; set; }

    public int IdNomina { get; set; }

    public int IdPassword { get; set; }

    public virtual Afiliacion IdAfiliacionNavigation { get; set; } = null!;

    public virtual Nomina IdNominaNavigation { get; set; } = null!;

    public virtual Access IdPasswordNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
