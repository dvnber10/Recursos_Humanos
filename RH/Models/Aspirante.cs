using System;
using System.Collections.Generic;

namespace RH.Models;

public partial class Aspirante
{
    public int IdAspirante { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public double Telefono { get; set; }

    public string Curriculum { get; set; } = null!;

    public int IdRegis { get; set; }

    public virtual ICollection<Contratacion> Contratacions { get; set; } = new List<Contratacion>();

    public virtual Registro IdRegisNavigation { get; set; } = null!;
}
