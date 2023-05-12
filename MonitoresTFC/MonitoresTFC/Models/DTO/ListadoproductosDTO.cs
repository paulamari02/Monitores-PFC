namespace MonitoresTFC.Models.DTO
{
    public partial class ListadoproductosDTO
    {
        public int ProductId { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string BrandName { get; set; } = string.Empty;

        public string ModelYear { get; set; } = string.Empty;

        public DateOnly DateProduccion { get; set; } = new DateOnly();

        public string? Description { get; set; } = string.Empty;
    }
}
