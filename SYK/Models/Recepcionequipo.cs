﻿using System;
using System.Collections.Generic;

namespace SYK.Models;

public partial class Recepcionequipo
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public int? TipoPc { get; set; }

    public string? Accesorio { get; set; }

    public string? MarcaPc { get; set; }

    public string? ModeloPc { get; set; }

    public string? Nserie { get; set; }

    public int? CapacidadRam { get; set; }

    public int? TipoAlmacenamiento { get; set; }

    public string? CapacidadAlmacenamiento { get; set; }

    public int? TipoGpu { get; set; }

    public string? Grafico { get; set; }

    public int ClienteId { get; set; }

    public int ServicioId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Servicio Servicio { get; set; } = null!;
}
