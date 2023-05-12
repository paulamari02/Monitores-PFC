using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Pedidos
{
    public partial class UpdatePedido
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateNombre { get; set; } = string.Empty;
        public int UpdateCliente { get; set; } = 0;
        public string UpdateStatus { get; set; } = string.Empty;
        public DateOnly UpdateFechaPedido { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? UpdateDescripcion { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private Listadopedido Pedido { get; set; } = new();
        private List<ListadoclientesDTO> Listadoclientes { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Listadoclientes = await rep.ListadoClientes();
        }
        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Pedido = rep.GetPedido(Id);

            UpdateNombre = Pedido.Nombre;
            UpdateCliente = Pedido.IdCliente;
            UpdateStatus = Pedido.StatusPedido;
            UpdateFechaPedido = Pedido.FechaPedido;
            UpdateDescripcion = Pedido.Descripcion;
        }

        public void UpdatePedidos()
        {
            if (string.IsNullOrWhiteSpace(UpdateNombre) || UpdateCliente == 0
                || string.IsNullOrWhiteSpace(UpdateStatus))
            {
                Missatge = "El pedido no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Pedido.Nombre = UpdateNombre;
                Pedido.IdCliente = UpdateCliente;
                Pedido.StatusPedido = UpdateStatus;
                Pedido.FechaPedido = UpdateFechaPedido;
                Pedido.Descripcion = UpdateDescripcion;

                if (rep.UpdatePedido(Pedido))
                {
                    Missatge = "El pedido se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoPedidos", true);
                }
                else
                {
                    Missatge = "El pedido no se ha podido modificar correctamente.";
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
            Nav.NavigateTo("/listadoPedidos", true);
        }
    }
}
