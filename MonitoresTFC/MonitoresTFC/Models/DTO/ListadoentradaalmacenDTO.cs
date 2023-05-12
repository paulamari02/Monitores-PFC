namespace MonitoresTFC.Models.DTO
{
    public partial class ListadoentradaalmacenDTO
    {
        public int IdEntrada { get; set; } = 0;

        public string Albaran { get; set; } = string.Empty;

        public DateOnly FechaEntrada { get; set; } = new DateOnly();

        public DateOnly FechaTransito { get; set; } = new DateOnly();

        public string Proveedor { get; set; } = string.Empty;

        public string Estado { get; set; } = string.Empty;

        public string Cantidad { get; set; } = string.Empty;

        public string Bultos { get; set; } = string.Empty;
    }
}
