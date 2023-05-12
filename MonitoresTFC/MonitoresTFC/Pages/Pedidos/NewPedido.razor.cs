using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Pedidos
{
    public partial class NewPedido
    {
        private string NewNombre { get; set; } = string.Empty;
        public int NewCliente { get; set; } = 0;
        public string NewStatus { get; set; } = string.Empty;
        public DateOnly NewFechaPedido { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string NewDescripcion { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;

        private List<ListadoclientesDTO> Listadoclientes { get; set; } = new();
        
        private Listadopedido pedido;

        protected override async Task OnInitializedAsync()
        {
            Listadoclientes = await rep.ListadoClientes();
        }


        private void AddPedido()
        {
            if (string.IsNullOrWhiteSpace(NewNombre) || NewCliente == 0 || 
                string.IsNullOrWhiteSpace(NewStatus) || !Checked)
            {
                Missatge = "El pedido no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                pedido = new Listadopedido
                {
                    Nombre = NewNombre,
                    IdCliente = NewCliente,
                    StatusPedido = NewStatus,
                    FechaPedido = NewFechaPedido,
                    Descripcion = NewDescripcion

                };

                if (rep.AddPedido(pedido))
                {
                    Missatge = "El pedido se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "El pedido no se ha podido añadir correctamente.";
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
