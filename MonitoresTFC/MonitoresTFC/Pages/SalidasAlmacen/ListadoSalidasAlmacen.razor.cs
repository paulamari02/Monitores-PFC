using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;

namespace MonitoresTFC.Pages.SalidasAlmacen
{
    public partial class ListadoSalidasAlmacen
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadosalidasalmacenDTO> ListSalidas { get; set; } = new();
        private List<ListadosalidasalmacenDTO> FilteredSalidas { get; set; } = new();
        private void LoadData() => ListSalidas = rep.ListadoSalidasAlmacen();
        private string SearchText { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;

        /*EXPORTAR*/
        private void ExportAllPages()
        {
            string carpeta = @"C:\Monitores";
            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = GetDataTable();
            wb.Worksheets.Add(dt, "Salidas");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoSalidasAlmacen_" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));

            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListSalidas(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredSalidas = rep.ListadoSalidasAlmacen();
            FilteredSalidas = FilteredSalidas.Where(c => c.Albaran.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Estado.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Articulo.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Cantidad.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Bultos.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Albaran");
            dt.Columns.Add("FechaSalida");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Articulo");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Bultos");

            foreach (var item in PaginatedListSalidas)
            {
                DataRow row = dt.NewRow();
                row["Albaran"] = item.Albaran;
                row["FechaSalida"] = item.FechaSalida;
                row["Proveedor"] = item.Proveedor;
                row["Estado"] = item.Estado;
                row["Articulo"] = item.Articulo;
                row["Cantidad"] = item.Cantidad;
                row["Bultos"] = item.Bultos;
                dt.Rows.Add(row);
            }
            return dt;
        }

        /*REDIRECCION*/
        void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
        
        /*PAGINACIÓN*/
        private List<ListadosalidasalmacenDTO> PaginatedListSalidas { get; set; } = new();
        private int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredSalidas.Count / (double)PageSize);
        protected override void OnInitialized()
        {
            LoadData();
            FilteredSalidas = ListSalidas;
            UpdatePaginatedListSalidas();
        }
        private void UpdatePaginatedListSalidas()
        {
            PaginatedListSalidas = FilteredSalidas.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListSalidas();
        }

        /*CRUD*/
        void NewSalida()
        {
            Nav.NavigateTo("/newSalida", true);
        }
        public void UpdateSalida(int id)
        {
            Nav.NavigateTo($"/updateSalida/{id}", true);
        }
        public void DeleteSalida(int id)
        {
            if (rep.DeleteSalida(id))
            {
                Missatge = "Salida eliminada correctamente.";
                Nav.NavigateTo("/listadoSalidasAlmacen", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }

        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar la salida {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeleteSalida(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }
}
