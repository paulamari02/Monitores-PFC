using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.SalidasAlmacen
{
    public partial class UpdateSalidas
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateAlbaran { get; set; } = string.Empty;
        public int UpdateProveedor { get; set; } = 0;
        public DateOnly UpdateFechaSalida { get; set; } = new DateOnly();
        public string UpdateEstado { get; set; } = string.Empty;
        public int UpdateArticulo { get; set; } = 0;
        public string UpdateCantidad { get; set; } = string.Empty;
        public string UpdateBultos { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        Listadosalidasalmacen Salida { get; set; } = new();
        private List<ListadoarticulosDTO> Listadoarticulos { get; set; } = new();
        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoarticulos = await rep.ListadoArticulos();
            Listadoproveedores = await rep.ListadoProveedores();
        }

        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Salida = rep.GetSalida(Id);

            UpdateAlbaran = Salida.Albaran;
            UpdateProveedor = Salida.IdProveedor;
            UpdateFechaSalida = Salida.FechaSalida;
            UpdateEstado = Salida.Estado;
            UpdateArticulo = Salida.IdArticulo;
            UpdateCantidad = Salida.Cantidad;
            UpdateBultos = Salida.Bultos;
        }

        public void UpdateSalida()
        {
            if (string.IsNullOrWhiteSpace(UpdateAlbaran) || UpdateProveedor == 0 ||
                string.IsNullOrWhiteSpace(UpdateEstado) || UpdateArticulo == 0 ||
                string.IsNullOrWhiteSpace(UpdateCantidad))
            {
                Missatge = "La salida no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Salida.Albaran = UpdateAlbaran;
                Salida.IdProveedor = UpdateProveedor;
                Salida.FechaSalida = UpdateFechaSalida;
                Salida.Estado = UpdateEstado;
                Salida.IdArticulo = UpdateArticulo;
                Salida.Cantidad = UpdateCantidad;
                Salida.Bultos = UpdateBultos;

                if (rep.UpdateSalida(Salida))
                {
                    Missatge = "La salida se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoSalidasAlmacen", true);
                }
                else
                {
                    Missatge = "La salida no se ha podido modificar correctamente.";
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
