
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Proveedor
{
    public partial class NewProveedor
    {
        private string NewNombre { get; set; } = string.Empty;
        public string NewNumFiscal { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public string NewTelefono { get; set; } = string.Empty;
        public string NewDireccion { get; set; } = string.Empty;
        public string NewCodigoPostal { get; set; } = string.Empty;
        public string? NewObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;


        private Listadoproveedore proveedor;

        private void AddProveedor()
        {
            if (string.IsNullOrWhiteSpace(NewNombre) || string.IsNullOrWhiteSpace(NewNumFiscal) ||
                string.IsNullOrWhiteSpace(NewEmail) || string.IsNullOrWhiteSpace(NewTelefono) ||
                string.IsNullOrWhiteSpace(NewDireccion) || string.IsNullOrWhiteSpace(NewCodigoPostal) || !Checked)
            {
                Missatge = "El proveedor no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                proveedor = new Listadoproveedore
                {
                    Nombre = NewNombre,
                    NumFiscal = NewNumFiscal,
                    CodigoPostal = NewCodigoPostal,
                    Direccion = NewDireccion,
                    Email = NewEmail,
                    Observaciones = NewObservaciones,
                    Telefono = NewTelefono
                };

                if (rep.AddProveedor(proveedor))
                {

                    Missatge = "El proveedor se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "El proveedor no se ha podido añadir correctamente.";
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
