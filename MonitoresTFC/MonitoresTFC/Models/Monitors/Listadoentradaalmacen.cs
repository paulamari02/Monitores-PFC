using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadoentradaalmacen
{
    public int IdEntrada { get; set; }

    public string Albaran { get; set; } = null!;

    public DateOnly FechaEntrada { get; set; }

    public DateOnly FechaTransito { get; set; }

    public int IdProveedor { get; set; }

    public string Estado { get; set; } = null!;

    public string Cantidad { get; set; } = null!;

    public string Bultos { get; set; } = null!;
}
