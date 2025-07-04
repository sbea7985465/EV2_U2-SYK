﻿using System;
using System.Collections.Generic;

namespace SYK.Models;

public partial class Servicio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Precio { get; set; }

    public string? Sku { get; set; }

    public int? Estado { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Descripcionservicio> Descripcionservicios { get; set; } = new List<Descripcionservicio>();

    public virtual ICollection<Recepcionequipo> Recepcionequipos { get; set; } = new List<Recepcionequipo>();

    public virtual Usuario Usuario { get; set; } = null!;
}
