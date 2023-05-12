using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Articulo 
{
    public partial class NewArticulo
    {
        private string NewArticulos { get; set; } = string.Empty;
        public string NewCodigoArticulo { get; set; } = string.Empty;
        public int NewProveedor { get; set; } = 0;
        public string NewStatus { get; set; } = string.Empty;
        public string? NewObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;

        private List<ListadoproveedoresDTO> Listadoproveedores { get; set; } = new();

        private Listadoarticulo articulo;

        protected override async Task OnInitializedAsync()
        {
            Listadoproveedores = await rep.ListadoProveedores();
        }

        private void AddArticle()
        {
            if (string.IsNullOrWhiteSpace(NewArticulos) || string.IsNullOrWhiteSpace(NewCodigoArticulo) 
                || NewProveedor == 0 || string.IsNullOrWhiteSpace(NewStatus) || !Checked)
            {
                Missatge = "El articulo no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                articulo = new Listadoarticulo
                {
                    Articulo = NewArticulos,
                    CodArticulo = NewCodigoArticulo,
                    IdProveedor = NewProveedor,
                    Status = NewStatus,
                    Observaciones = NewObservaciones
                };

                if (rep.AddArticle(articulo))
                {
                    Missatge = "El articulo se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "El articulo no se ha podido añadir correctamente.";
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

