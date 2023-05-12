using MonitoresTFC.Models.DTO;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Data
{
    public interface IRepository
    {
        Task<List<ListadoclientesDTO>> ListadoClientes();
        Task<List<ListadoproveedoresDTO>> ListadoProveedores();
        List<ListadopedidosDTO> ListadoPedidos();
        Task<List<ListadoarticulosDTO>> ListadoArticulos();
        List<ListadoarticulosDTO> ListadoArticulosGraf();
        List<ListadoentradaalmacenDTO> ListadoEntradaAlmacen();
        List<ListadosalidasalmacenDTO> ListadoSalidasAlmacen();

        /*CLIENTE*/
        Listadocliente GetCliente(int id);
        bool AddCliente(Listadocliente cliente);
        bool UpdateCliente(Listadocliente cliente);
        bool DeleteCliente(int id);

        /*PROVEEDOR*/
        Listadoproveedore GetProveedor(int id);
        bool AddProveedor(Listadoproveedore proveedor);
        bool UpdateProveedor(Listadoproveedore proveedor);
        bool DeleteProveedor(int id);

        /*PEDIDOS*/
        Listadopedido GetPedido(int id);
        bool AddPedido(Listadopedido pedido);
        bool UpdatePedido(Listadopedido pedido);
        bool DeletePedido(int id);

        /*ARTICULO*/
        Listadoarticulo GetArticulo(int id);
        bool AddArticle(Listadoarticulo articulo);
        bool UpdateArticle(Listadoarticulo articulo);
        bool DeleteArticle(int id);


        /*SALIDAS*/
        Listadosalidasalmacen GetSalida(int id);
        bool AddSalida(Listadosalidasalmacen salidas);
        bool UpdateSalida(Listadosalidasalmacen articulo);
        bool DeleteSalida(int id);

        /*ENTRADAS*/
        Listadoentradaalmacen GetEntrada(int id);
        bool AddEntrada(Listadoentradaalmacen entrada);
        bool UpdateEntrada(Listadoentradaalmacen articulo);
        bool DeleteEntrada(int id);
    }
}
