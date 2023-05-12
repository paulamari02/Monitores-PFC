namespace MonitoresTFC.Models.DTO
{
    public partial class ListadopedidosDTO
    {
        public int IdPedido { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty!;
        public string Cliente { get; set; } = string.Empty;
        public string StatusPedido { get; set; } = string.Empty;
        public DateOnly FechaPedido { get; set; } = new DateOnly();
        public string? Descripcion { get; set; } = string.Empty;
    }
}
