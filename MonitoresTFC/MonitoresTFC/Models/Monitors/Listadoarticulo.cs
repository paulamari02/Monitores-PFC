using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadoarticulo
{
    public int IdArticulo { get; set; }

    public string Articulo { get; set; } = null!;

    public string CodArticulo { get; set; } = null!;

    public int IdProveedor { get; set; }

    public string Status { get; set; } = null!;

    public string? Observaciones { get; set; }
}
