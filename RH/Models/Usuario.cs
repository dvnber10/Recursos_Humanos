using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public double Documento { get; set; }

    public string Direccion { get; set; } = null!;

    public double Telefono { get; set; }

    public string Cargo { get; set; } = null!;

    public string? Contraseña { get; set; }

    public int? Idcontratacion { get; set; }

    public int IdRol { get; set; }

    public byte[]? Curriculum { get; set; }

    public virtual ICollection<Afiliacion> Afiliacions { get; set; } = new List<Afiliacion>();

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Contratacion? IdcontratacionNavigation { get; set; }

    public virtual ICollection<Nomina> Nominas { get; set; } = new List<Nomina>();

    public virtual ICollection<Registro> Registros { get; set; } = new List<Registro>();
    [NotMapped]
    public bool SesionActiva {get;set;}
}
