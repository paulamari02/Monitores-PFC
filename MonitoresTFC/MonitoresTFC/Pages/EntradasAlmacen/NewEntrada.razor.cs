using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.EntradasAlmacen
{
    public partial class NewEntrada
    {
        private string NewAlbaran { get; set; } = string.Empty;
        public DateOnly NewFechaEntrada { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly NewFechaTransito { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int NewProveedor { get; set; } = 0;
        public string NewEstado { get; set; } = string.Empty;
        public string NewCantidad { get; set; } = string.Empty;
        public string? NewBultos { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;


        private Listadoentradaalmacen entrada;
        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoproveedores = await rep.ListadoProveedores();
        }

        private void AddEntrada()
        {
            if (string.IsNullOrWhiteSpace(NewAlbaran) || NewProveedor == 0
                || string.IsNullOrWhiteSpace(NewEstado) || string.IsNullOrWhiteSpace(NewCantidad) || !Checked)
            {
                Missatge = "La entrada no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                entrada = new Listadoentradaalmacen
                {
                    Albaran = NewAlbaran,
                    FechaEntrada = NewFechaEntrada,
                    FechaTransito = NewFechaTransito,
                    IdProveedor = NewProveedor,
                    Estado = NewEstado,
                    Cantidad = NewCantidad,
                    Bultos = NewBultos

                };

                if (rep.AddEntrada(entrada))
                {
                    Missatge = "La entrada se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "La entrada no se ha podido añadir correctamente.";
                }
            }
        }

        /*REDIRECCION*/
        void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
        void GoBack()
        {
            Nav.NavigateTo("/listadoEntradaAlmacen", true);
        }
    }
}
