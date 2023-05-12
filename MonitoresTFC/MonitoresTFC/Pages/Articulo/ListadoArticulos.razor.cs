using BootstrapBlazor.Components;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;

namespace MonitoresTFC.Pages.Articulo
{
    public partial class ListadoArticulos
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadoarticulosDTO> ListArticulos { get; set; } = new();
        private List<ListadoarticulosDTO> FilteredArticulos { get; set; } = new();
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
            wb.Worksheets.Add(dt, "Articulos");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoArticulos_" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));
            
            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListArticulos(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredArticulos = await rep.ListadoArticulos();
            FilteredArticulos = FilteredArticulos.Where(c => c.Articulo.ToUpper().Contains(SearchText.ToUpper()) ||
                                                             c.CodArticulo.ToUpper().Contains(SearchText.ToUpper()) ||
                                                             c.Proveedor.ToUpper().Contains(SearchText.ToUpper()) ||
                                                             c.Status.ToUpper().Contains(SearchText.ToUpper()) ||
                                                             c.Observaciones.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Articulo");
            dt.Columns.Add("Código articulo");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("Status");
            dt.Columns.Add("Observaciones");

            foreach (var item in PaginatedListArticulos)
            {
                DataRow row = dt.NewRow();
                row["Articulo"] = item.Articulo;
                row["Código articulo"] = item.CodArticulo;
                row["Proveedor"] = item.Proveedor;
                row["Status"] = item.Status;
                row["Observaciones"] = item.Observaciones;
            }
            return dt;
        }

        /*REDIRECCION*/
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }

        /*PAGINACIÓN*/
        private List<ListadoarticulosDTO> PaginatedListArticulos { get; set; } = new();
        private readonly int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredArticulos.Count / (double)PageSize);
        protected override void OnInitialized()
        {
            ListArticulos = rep.ListadoArticulosGraf();
            FilteredArticulos = ListArticulos;
            UpdatePaginatedListArticulos();
        }
        private void UpdatePaginatedListArticulos()
        {
            PaginatedListArticulos = FilteredArticulos.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListArticulos();
        }

        /*CRUD*/
        public void NewArticulo()
        {
            Nav.NavigateTo("/newArticulo", true);
        }
        public void UpdateArticulo(int id)
        {
            Nav.NavigateTo($"/updateArticulo/{id}", true);
        }
        public void DeleteArticulo(int id)
        {
            if (rep.DeleteArticle(id))
            {
                Missatge = "Artículo eliminado correctamente.";
                Nav.NavigateTo("/listadoArticulos", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }

        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar el artículo {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeleteArticulo(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }
}
