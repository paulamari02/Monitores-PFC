namespace MonitoresTFC.Models.DTO
{
    public partial class ListadoproveedoresDTO
    {
        public int IdProveedor { get; set; } = 0;

        public string Nombre { get; set; } = string.Empty;

        public string NumFiscal { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string CodigoPostal { get; set; } = string.Empty;

        public string? Observaciones { get; set; } = string.Empty;
    }
}
