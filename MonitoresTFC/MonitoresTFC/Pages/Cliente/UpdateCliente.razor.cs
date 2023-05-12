using Microsoft.AspNetCore.Components;
using MonitoresTFC.Models.Monitors;
using System.Data;

namespace MonitoresTFC.Pages.Cliente
{
    public partial class UpdateCliente
    {
        [Parameter]
        public string id { get; set; }
        private string UpdateNombre { get; set; } = string.Empty;
        public string UpdateApellidos { get; set; } = string.Empty;
        public string UpdateEmail { get; set; } = string.Empty;
        public string UpdateTelefono { get; set; } = string.Empty;
        public string UpdateDireccion { get; set; } = string.Empty;
        public string UpdateCodigoPostal { get; set; } = string.Empty;
        public DateOnly UpdateFechaalta { get; set; } = new DateOnly();
        public string? UpdateObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        Listadocliente Cliente { get; set; } = new();

        protected override void OnInitialized()
        {
            _ = int.TryParse(id, out int Id);
            Cliente = rep.GetCliente(Id);

            UpdateNombre = Cliente.Nombre;
            UpdateApellidos = Cliente.Apellidos;
            UpdateEmail = Cliente.Email;
            UpdateTelefono = Cliente.Telefono;
            UpdateDireccion = Cliente.Direccion;
            UpdateCodigoPostal = Cliente.CodigoPostal;
            UpdateFechaalta = Cliente.Fechaalta;
            UpdateObservaciones = Cliente.Observaciones;
        }

        private void UpdateClient()
        {
            if (string.IsNullOrWhiteSpace(UpdateNombre) || string.IsNullOrWhiteSpace(UpdateApellidos) ||
                string.IsNullOrWhiteSpace(UpdateEmail) || string.IsNullOrWhiteSpace(UpdateTelefono) ||
                string.IsNullOrWhiteSpace(UpdateDireccion) || string.IsNullOrWhiteSpace(UpdateCodigoPostal))
            {
                Missatge = "El artículo no se ha podido modificar correctamente, faltan campos por completar.";
            }
            else
            {
                Cliente.Nombre = UpdateNombre;
                Cliente.Apellidos = UpdateApellidos;
                Cliente.CodigoPostal = UpdateCodigoPostal;
                Cliente.Direccion = UpdateDireccion;
                Cliente.Email = UpdateEmail;
                Cliente.Fechaalta = UpdateFechaalta;
                Cliente.Observaciones = UpdateObservaciones;
                Cliente.Telefono = UpdateTelefono;


                if (rep.UpdateCliente(Cliente))
                {
                    Missatge = "El cliente se ha modificado correctamente.";
                    Nav.NavigateTo("/listadoClientes", true);
                }
                else
                {
                    Missatge = "El cliente no se ha podido modificado correctamente.";
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
            Nav.NavigateTo("/listadoClientes", true);
        }
    }
}
