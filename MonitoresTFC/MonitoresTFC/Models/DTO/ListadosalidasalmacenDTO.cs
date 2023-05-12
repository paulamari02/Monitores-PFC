namespace MonitoresTFC.Models.DTO
{
    public partial class ListadosalidasalmacenDTO
    {
        public int IdSalidas { get; set; } = 0;

        public string Albaran { get; set; } = string.Empty;

        public string Proveedor { get; set; } = string.Empty;

        public DateOnly FechaSalida { get; set; } = new DateOnly();

        public string Estado { get; set; } = string.Empty;

        public string Articulo { get; set; } = string.Empty;

        public string Cantidad { get; set; } = string.Empty;

        public string Bultos { get; set; } = string.Empty;
    }
}
