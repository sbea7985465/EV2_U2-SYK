using System;
using System.Collections.Generic;

namespace SYK.Models;

public partial class Descripcionservicio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int ServicioId { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;
}
