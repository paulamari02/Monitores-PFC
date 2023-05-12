using MonitoresTFC.Models.DTO;

namespace MonitoresTFC.Components
{
    public partial class MenuHome
    {
        public List<MenuDTO> MenuItem { get; set; } = new();

        protected override void OnInitialized()
        {
            MenuItem.AddRange(new List<MenuDTO>()
            {
                new MenuDTO("Listado pedidos","fa-cart-flatbed", "/listadoPedidos", 1),
                new MenuDTO("Listado artículos","fa-list-ul", "/listadoArticulos", 1),
                new MenuDTO("Gráficos pedidos","fa-chart-pie", "/graficosPedidos", 1),

                new MenuDTO("Listado clientes","fa-circle-user", "/listadoClientes", 2),
                new MenuDTO("Listado proveedores","fa-handshake", "/listadoProveedores", 2),

                new MenuDTO("Salidas de almacén","fa-boxes-packing", "/listadoSalidasAlmacen", 3),
                new MenuDTO("Entradas almacén","fa-boxes-stacked", "/listadoEntradaAlmacen", 3),
                new MenuDTO("Gráficos almacén","fa-chart-column", "/graficosAlmacen", 3),

            });
        }

    }
}
