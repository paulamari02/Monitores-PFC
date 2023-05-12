using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Proveedor
{
    public partial class UpdateProveedor
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateNombre { get; set; } = string.Empty;
        public string UpdateNumFiscal { get; set; } = string.Empty;
        public string UpdateEmail { get; set; } = string.Empty;
        public string UpdateTelefono { get; set; } = string.Empty;
        public string UpdateDireccion { get; set; } = string.Empty;
        public string UpdateCodigoPostal { get; set; } = string.Empty;
        public string? UpdateObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        Listadoproveedore Proveedor { get; set; } = new();

        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Proveedor = rep.GetProveedor(Id);

            UpdateNombre = Proveedor.Nombre;
            UpdateNumFiscal = Proveedor.NumFiscal;
            UpdateEmail = Proveedor.Email;
            UpdateTelefono = Proveedor.Telefono;
            UpdateDireccion = Proveedor.Direccion;
            UpdateCodigoPostal = Proveedor.CodigoPostal;
            UpdateObservaciones = Proveedor.Observaciones;
        }

        public void UpdateProveedors()
        {
            if (string.IsNullOrWhiteSpace(UpdateNombre) || string.IsNullOrWhiteSpace(UpdateNumFiscal) ||
                string.IsNullOrWhiteSpace(UpdateEmail) || string.IsNullOrWhiteSpace(UpdateTelefono) ||
                string.IsNullOrWhiteSpace(UpdateDireccion) || string.IsNullOrWhiteSpace(UpdateCodigoPostal))
            {
                Missatge = "El proveedor no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Proveedor.Nombre = UpdateNombre;
                Proveedor.NumFiscal = UpdateNumFiscal;
                Proveedor.Email = UpdateEmail;
                Proveedor.Telefono = UpdateTelefono;
                Proveedor.Direccion = UpdateDireccion;
                Proveedor.CodigoPostal = UpdateCodigoPostal;
                Proveedor.Observaciones = UpdateObservaciones;

                if (rep.UpdateProveedor(Proveedor))
                {
                    Missatge = "El proveedor se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoProveedores", true);
                }
                else
                {
                    Missatge = "El proveedor no se ha podido modificar correctamente.";
                }
            }
        }

        /*REDIRECCION*/
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
        public void GoBack()
        {
            Nav.NavigateTo("/listadoProveedores", true);
        }
    }
}
