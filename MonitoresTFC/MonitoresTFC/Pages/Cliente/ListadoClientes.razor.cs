using ClosedXML.Excel;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.DTO;
using System.Data;


namespace MonitoresTFC.Pages.Cliente
{
    public partial class ListadoClientes
    {
        Components.ModalDialog ModalDialogs { get; set; }
        private List<ListadoclientesDTO> ListClientes { get; set; } = new();
        private List<ListadoclientesDTO> FilteredClientes { get; set; } = new();
        private async Task LoadData() => ListClientes = await rep.ListadoClientes();
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
            wb.Worksheets.Add(dt, "Clientes");
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string nombreArchivo = "ListadoClientes_" + fechaActual + ".xlsx";
            wb.SaveAs(Path.Combine(carpeta, nombreArchivo));

            Missatge = "Documento descargado en C:\\Monitores";
        }

        /*FILTRADO*/
        private async Task FilterListClientes(ChangeEventArgs e)
        {
            SearchText = e.Value.ToString();
            FilteredClientes = await rep.ListadoClientes();
            FilteredClientes = FilteredClientes.Where(c => c.Nombre.ToUpper().Contains(SearchText.ToUpper()) ||
                                                           c.Apellidos.ToUpper().Contains(SearchText.ToUpper()) ||
                                                           c.Email.ToUpper().Contains(SearchText.ToUpper()) ||
                                                           c.Direccion.ToUpper().Contains(SearchText.ToUpper()) ||
                                                           c.CodigoPostal.ToUpper().Contains(SearchText.ToUpper()) ||
                                                           c.Telefono.ToUpper().Contains(SearchText.ToUpper())).ToList();
            ChangePage(1);
        }
        private DataTable GetDataTable()
        {
            DataTable dt = new();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Email");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("CodPostal");
            dt.Columns.Add("Telefono");

            foreach (var item in PaginatedListClientes)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = item.Nombre;
                row["Apellidos"] = item.Apellidos;
                row["Email"] = item.Email;
                row["Direccion"] = item.Direccion;
                row["CodPostal"] = item.CodigoPostal;
                row["Telefono"] = item.Telefono;
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
        private List<ListadoclientesDTO> PaginatedListClientes { get; set; } = new();
        private int PageSize = 8;
        private int PageIndex = 1;
        private int TotalPages => (int)Math.Ceiling(FilteredClientes.Count / (double)PageSize);
        protected override async Task OnInitializedAsync()
        {
            await LoadData();
            FilteredClientes = ListClientes;
            UpdatePaginatedListClientes();
        }
        private void UpdatePaginatedListClientes()
        {
            PaginatedListClientes = FilteredClientes.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        }
        private void ChangePage(int pageNumber)
        {
            PageIndex = pageNumber;
            UpdatePaginatedListClientes();
        }

        /*CRUD*/
        public void NewCliente()
        {
            Nav.NavigateTo("/newCliente", true);
        }
        public void UpdateCliente(int id)
        {
            Nav.NavigateTo($"/updateCliente/{id}", true);
        }
        public void DeleteCliente(int id)
        {
            if (rep.DeleteCliente(id))
            {
                Missatge = "Cliente eliminado correctamente.";
                Nav.NavigateTo("/listadoClientes", true);
            }
            else
                Missatge = "No se ha podido eliminar.";
        }

        /*Modal Borrar*/
        public void OnConfirmDelete(string name, int id)
        {
            ModalDialogs.Id = id;
            ModalDialogs.Name = name;
            ModalDialogs.ChildContent = $"¿Quieres borrar el cliente {name}?";
            ModalDialogs.Show();
        }

        public void DeleteContact()
        {

            DeleteCliente(ModalDialogs.Id);
            StateHasChanged();
            ModalDialogs.Close();
        }
    }

}
