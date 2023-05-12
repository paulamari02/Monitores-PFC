using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Articulo
{
    public partial class UpdateArticulo
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateArticulos { get; set; } = string.Empty;
        public string UpdateCodigoArticulo { get; set; } = string.Empty;
        public int UpdateProveedor { get; set; } = 0;
        public string UpdateStatus { get; set; } = string.Empty;
        public string? UpdateObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        Listadoarticulo Articulo { get; set; } = new();
        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoproveedores = await rep.ListadoProveedores();
        }
        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Articulo = rep.GetArticulo(Id);

            UpdateArticulos = Articulo.Articulo;
            UpdateCodigoArticulo = Articulo.CodArticulo;
            UpdateProveedor = Articulo.IdProveedor;
            UpdateStatus = Articulo.Status;
            UpdateObservaciones = Articulo.Observaciones;
        }

        public void UpdateArticle()
        {
            if (string.IsNullOrWhiteSpace(UpdateArticulos) || string.IsNullOrWhiteSpace(UpdateCodigoArticulo)
                || UpdateProveedor == 0 || string.IsNullOrWhiteSpace(UpdateStatus))
            {
                Missatge = "El artículo no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Articulo.Articulo = UpdateArticulos;
                Articulo.CodArticulo = UpdateCodigoArticulo;
                Articulo.IdProveedor = UpdateProveedor;
                Articulo.Status = UpdateStatus;
                Articulo.Observaciones = UpdateObservaciones;

                if (rep.UpdateArticle(Articulo))
                {
                    Missatge = "El artículo se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoArticulos", true);
                }
                else
                {
                    Missatge = "El artículo no se ha podido modificar correctamente.";
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
            Nav.NavigateTo("/listadoArticulos", true);
        }
    }
}
