using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadocliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public DateOnly Fechaalta { get; set; }

    public string? Observaciones { get; set; }
}
