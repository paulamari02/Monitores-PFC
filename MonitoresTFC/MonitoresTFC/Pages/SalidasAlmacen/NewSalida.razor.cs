using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.SalidasAlmacen
{
    public partial class NewSalida
    {
        private string NewAlbaran { get; set; } = string.Empty;
        public int NewProveedor { get; set; } = 0;
        public DateOnly NewFechaSalida { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string NewEstado { get; set; } = string.Empty;
        public int NewArticulo { get; set; } = 0;
        public string NewCantidad { get; set; } = string.Empty;
        public string? NewBultos { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;

        private Listadosalidasalmacen salidas;

        private List<ListadoarticulosDTO> Listadoarticulos { get; set; } = new();
        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoarticulos = await rep.ListadoArticulos();
            Listadoproveedores = await rep.ListadoProveedores();
        }

        private void AddSalida()
        {
            if (string.IsNullOrWhiteSpace(NewAlbaran) || NewProveedor == 0 ||
                string.IsNullOrWhiteSpace(NewEstado) || NewArticulo == 0 ||
                string.IsNullOrWhiteSpace(NewCantidad) || !Checked)
            {
                Missatge = "La salida no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                salidas = new Listadosalidasalmacen
                {
                    Albaran = NewAlbaran,
                    IdProveedor = NewProveedor,
                    FechaSalida = NewFechaSalida,
                    Estado = NewEstado,
                    IdArticulo = NewArticulo,
                    Cantidad = NewCantidad,
                    Bultos = NewBultos

                };

                if (rep.AddSalida(salidas))
                {
                    Missatge = "La salidas se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "La salidas no se ha podido añadir correctamente.";
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
            Nav.NavigateTo("/listadoSalidasAlmacen", true);
        }
    }
}
