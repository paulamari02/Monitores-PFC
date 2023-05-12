using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;

namespace MonitoresTFC.Pages.Pedidos
{
    public partial class ListadoPedidos
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadopedidosDTO> ListPedidos { get; set; } = new();
        private List<ListadopedidosDTO> FilteredPedidos { get; set; } = new();
        private void LoadData() => ListPedidos = rep.ListadoPedidos();
        private string SearchText { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;


        /*EXPORTAR*/
        private void ExportAllPages()
        {
            string carpeta = @"C:\Monitores";
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
            XLWorkbook wb = new();
            DataTable dt = GetDataTable();
            wb.Worksheets.Add(dt, "Pedidos");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoPedidos" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));

            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListPedidos(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredPedidos = rep.ListadoPedidos();
            FilteredPedidos = FilteredPedidos.Where(c => c.Nombre.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Cliente.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.StatusPedido.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Descripcion.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("IdCliente");
            dt.Columns.Add("Status pedido");
            dt.Columns.Add("Fecha pedido");
            dt.Columns.Add("Descripcion");

            foreach (var item in PaginatedListPedidos)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = item.Nombre;
                row["IdCliente"] = item.Cliente;
                row["Status pedido"] = item.StatusPedido;
                row["Fecha pedido"] = item.FechaPedido;
                row["Descripcion"] = item.Descripcion;
            }
            return dt;
        }

        /*REDIRECCION*/
        void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }

        /*PAGINACIÓN*/
        private List<ListadopedidosDTO> PaginatedListPedidos { get; set; } = new();
        private int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredPedidos.Count / (double)PageSize);
        protected override void OnInitialized()
        {
            LoadData();
            FilteredPedidos = ListPedidos;
            UpdatePaginatedListPedidos();
        }
        private void UpdatePaginatedListPedidos()
        {
            PaginatedListPedidos = FilteredPedidos.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListPedidos();
        }

        /*CRUD*/
        public void NewPedido()
        {
            Nav.NavigateTo("/newPedido", true);
        }
        public void UpdatePedido(int id)
        {
            Nav.NavigateTo($"/updatePedido/{id}", true);
        }
        public void DeletePedido(int id)
        {
            if (rep.DeletePedido(id))
            {
                Missatge = "Pedido eliminado correctamente.";
                Nav.NavigateTo("/listadoPedidos", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }

        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar el pedido {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeletePedido(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }
}
