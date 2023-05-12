namespace MonitoresTFC.Models.DTO
{
    public class ListadoarticulosDTO
    {
        public int IdArticulo { get; set; } = 0;

        public string Articulo { get; set; } = string.Empty;

        public string CodArticulo { get; set; } = string.Empty;

        public string Proveedor { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Observaciones { get; set; } = string.Empty;
    }
}
