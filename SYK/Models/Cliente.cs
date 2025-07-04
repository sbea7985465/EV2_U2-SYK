using System;
using System.Collections.Generic;

namespace SYK.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Dirrecion { get; set; }

    public int? Estado { get; set; }

    public virtual ICollection<Recepcionequipo> Recepcionequipos { get; set; } = new List<Recepcionequipo>();
}
