namespace MonitoresTFC.Models.DTO
{
    public partial class ListadoclientesDTO
    {
        public int IdCliente { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string CodigoPostal { get; set; } = string.Empty;

        public DateOnly Fechaalta { get; set; } = new DateOnly();

        public string? Observaciones { get; set; } = string.Empty;
    }
}
