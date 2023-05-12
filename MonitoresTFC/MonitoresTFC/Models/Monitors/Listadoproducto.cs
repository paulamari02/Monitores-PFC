using System;
using System.Collections.Generic;

namespace MonitoresTFC.Models.Monitors;

public partial class Listadoproducto
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public string ModelYear { get; set; } = null!;

    public DateOnly DateProduccion { get; set; }

    public string? Description { get; set; }
}
