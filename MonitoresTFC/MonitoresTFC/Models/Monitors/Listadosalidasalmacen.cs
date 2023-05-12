using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadosalidasalmacen
{
    public int IdSalidas { get; set; }

    public string Albaran { get; set; } = null!;

    public int IdProveedor { get; set; }

    public DateOnly FechaSalida { get; set; }

    public string Estado { get; set; } = null!;

    public int IdArticulo { get; set; }

    public string Cantidad { get; set; } = null!;

    public string Bultos { get; set; } = null!;
}
