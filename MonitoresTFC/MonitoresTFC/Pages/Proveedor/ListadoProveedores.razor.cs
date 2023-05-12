using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;

namespace MonitoresTFC.Pages.Proveedor
{
    public partial class ListadoProveedores
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadoproveedoresDTO> ListProveedores { get; set; } = new();
        private List<ListadoproveedoresDTO> FilteredProveedores { get; set; } = new();
        private async Task LoadData() => ListProveedores = await rep.ListadoProveedores();
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
            wb.Worksheets.Add(dt, "Proveedores");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoProveedores_" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));

            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListProveedores(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredProveedores = await rep.ListadoProveedores();
            FilteredProveedores = FilteredProveedores.Where(c => c.Nombre.ToUpper().Contains(SearchText.ToUpper()) ||
                                                                 c.Email.ToUpper().Contains(SearchText.ToUpper()) ||
                                                                 c.NumFiscal.ToUpper().Contains(SearchText.ToUpper()) ||
                                                                 c.Direccion.ToUpper().Contains(SearchText.ToUpper()) ||
                                                                 c.CodigoPostal.ToUpper().Contains(SearchText.ToUpper()) ||
                                                                 c.Telefono.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Email");
            dt.Columns.Add("NumFiscal");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("CodPostal");
            dt.Columns.Add("Telefono");

            foreach (var item in PaginatedListProveedores)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = item.Nombre;
                row["Email"] = item.Email;
                row["NumFiscal"] = item.NumFiscal;
                row["Direccion"] = item.Direccion;
                row["CodPostal"] = item.CodigoPostal;
                row["Telefono"] = item.Telefono;
                dt.Rows.Add(row);
            }
            return dt;
        }
        
        /*REDIRECCION*/
        private void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
       
        /*PAGINACIÓN*/
        private List<ListadoproveedoresDTO> PaginatedListProveedores { get; set; } = new();
        private int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredProveedores.Count / (double)PageSize);
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            FilteredProveedores = ListProveedores;
            UpdatePaginatedListProveedores();
        }
        private void UpdatePaginatedListProveedores()
        {
            PaginatedListProveedores = FilteredProveedores.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListProveedores();
        }

        /*CRUD*/
        public void NewProveedor()
        {
            Nav.NavigateTo("/newProveedor", true);
        }
        public void UpdateProveedor(int id)
        {
            Nav.NavigateTo($"/updateProveedor/{id}", true);
        }
        public void DeleteProveedor(int id)
        {
            if (rep.DeleteProveedor(id))
            {
                Missatge = "Proveedor eliminado correctamente.";
                Nav.NavigateTo("/listadoProveedores", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }
        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar el proveedor {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeleteProveedor(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }
}
