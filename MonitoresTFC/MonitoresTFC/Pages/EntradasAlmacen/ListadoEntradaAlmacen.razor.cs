using BootstrapBlazor.Components;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;

namespace MonitoresTFC.Pages.EntradasAlmacen
{
    public partial class ListadoEntradaAlmacen
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadoentradaalmacenDTO> ListEntrada { get; set; } = new();
        private List<ListadoentradaalmacenDTO> FilteredEntrada { get; set; } = new();
        private void LoadData() => ListEntrada =  rep.ListadoEntradaAlmacen();
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
            wb.Worksheets.Add(dt, "Entradas");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoEntradaAlmacen_" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));

            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListEntrada(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredEntrada = rep.ListadoEntradaAlmacen();
            FilteredEntrada = FilteredEntrada.Where(c => c.Albaran.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Proveedor.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Estado.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Cantidad.ToUpper().Contains(SearchText.ToUpper()) ||
                                                         c.Bultos.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Albaran");
            dt.Columns.Add("FechaSalida");
            dt.Columns.Add("FechaTransito");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Bultos");

            foreach (var item in PaginatedListEntrada)
            {
                DataRow row = dt.NewRow();
                row["Albaran"] = item.Albaran;
                row["FechaSalida"] = item.FechaEntrada;
                row["FechaTransito"] = item.FechaTransito;
                row["Proveedor"] = item.Proveedor;
                row["Estado"] = item.Estado;
                row["Cantidad"] = item.Cantidad;
                row["Bultos"] = item.Bultos;
                dt.Rows.Add(row);
            }
            return dt;
        }

        /*REDIRECCION*/
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
       
        /*PAGINACIÓN*/
        private List<ListadoentradaalmacenDTO> PaginatedListEntrada { get; set; } = new();
        private int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredEntrada.Count / (double)PageSize);
        protected override void OnInitialized()
        {
            LoadData();
            FilteredEntrada = ListEntrada;
            UpdatePaginatedListEntrada();
        }
        private void UpdatePaginatedListEntrada()
        {
            PaginatedListEntrada = FilteredEntrada.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListEntrada();
        }

        /*CRUD*/
        public void NewEntrada()
        {
            Nav.NavigateTo("/newEntrada", true);
        }
        public void UpdateEntrada(int id)
        {
            Nav.NavigateTo($"/updateEntrada/{id}", true);
        }
        public void DeleteEntrada(int id)
        {
            if (rep.DeleteEntrada(id))
            {
                Missatge = "Entrada eliminada correctamente.";
                Nav.NavigateTo("/listadoEntradaAlmacen", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }
        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar la entrada {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeleteEntrada(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }
}
