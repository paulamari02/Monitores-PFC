using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;
using MonitoresTFC.Pages.Articulo;
using System.Data;

namespace MonitoresTFC.Pages.EntradasAlmacen
{
    public partial class UpdateEntrada
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateAlbaran { get; set; } = string.Empty;
        public DateOnly UpdateFechaEntrada { get; set; } = new DateOnly();
        public DateOnly UpdateFechaTransito { get; set; } = new DateOnly();
        public int UpdateProveedor { get; set; } = 0;
        public string UpdateEstado { get; set; } = string.Empty;
        public string UpdateCantidad { get; set; } = string.Empty;
        public string? UpdateBultos { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        Listadoentradaalmacen Entrada { get; set; } = new();
        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoproveedores = await rep.ListadoProveedores();
        }
        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Entrada = rep.GetEntrada(Id);

            UpdateAlbaran = Entrada.Albaran;
            UpdateFechaEntrada = Entrada.FechaEntrada;
            UpdateFechaTransito = Entrada.FechaTransito;
            UpdateProveedor = Entrada.IdProveedor;
            UpdateEstado = Entrada.Estado;
            UpdateCantidad = Entrada.Cantidad;
            UpdateBultos = Entrada.Bultos;
        }

        public void UpdateEntradas()
        {
            if (string.IsNullOrWhiteSpace(UpdateAlbaran) || UpdateProveedor == 0
                || string.IsNullOrWhiteSpace(UpdateEstado) || string.IsNullOrWhiteSpace(UpdateCantidad))
            {
                Missatge = "La entrada no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Entrada.Albaran = UpdateAlbaran;
                Entrada.FechaEntrada = UpdateFechaEntrada;
                Entrada.FechaTransito = UpdateFechaTransito;
                Entrada.IdProveedor = UpdateProveedor;
                Entrada.Estado = UpdateEstado;
                Entrada.Cantidad = UpdateCantidad;
                Entrada.Bultos = UpdateBultos;

                if (rep.UpdateEntrada(Entrada))
                {
                    Missatge = "La entrada se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoEntradaAlmacen", true);
                }
                else
                {
                    Missatge = "La entrada no se ha podido modificar correctamente.";
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
