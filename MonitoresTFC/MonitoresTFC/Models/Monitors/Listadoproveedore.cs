using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadoproveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string NumFiscal { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string CodigoPostal { get; set; } = null!;

    public string? Observaciones { get; set; }
}
