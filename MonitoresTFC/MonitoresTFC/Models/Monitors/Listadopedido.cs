using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadopedido
{
    public int IdPedido { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdCliente { get; set; }

    public string StatusPedido { get; set; } = null!;

    public DateOnly FechaPedido { get; set; }

    public string? Descripcion { get; set; }
}
