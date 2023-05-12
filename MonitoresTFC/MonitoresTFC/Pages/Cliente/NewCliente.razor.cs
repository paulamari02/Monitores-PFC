
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Pages.Cliente
{
    public partial class NewCliente
    {
        private string NewNombre { get; set; } = string.Empty;
        public string NewApellidos { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public string NewTelefono { get; set; } = string.Empty;
        public string NewDireccion { get; set; } = string.Empty;
        public string NewCodigoPostal { get; set; } = string.Empty;
        public DateOnly NewFechaalta { get; set; } = DateOnly.FromDateTime( DateTime.Now);
        public string? NewObservaciones { get; set; } = string.Empty;
        private string Missatge { get; set; } = string.Empty;
        private bool Checked { get; set; } = false;


        private Listadocliente cliente;


        private void AddClient()
        {
            if (string.IsNullOrWhiteSpace(NewNombre) || string.IsNullOrWhiteSpace(NewApellidos)|| 
                string.IsNullOrWhiteSpace(NewEmail) || string.IsNullOrWhiteSpace(NewTelefono) ||
                string.IsNullOrWhiteSpace(NewDireccion) || string.IsNullOrWhiteSpace(NewCodigoPostal) || 
                string.IsNullOrWhiteSpace(NewTelefono) || !Checked)
            {
                Missatge = "El articulo no se ha podido añadir correctamente, faltan campos por completar.";
            }
            else
            {
                cliente = new Listadocliente
                {
                    Nombre = NewNombre,
                    Apellidos = NewApellidos,
                    CodigoPostal = NewCodigoPostal,
                    Direccion = NewDireccion,
                    Email = NewEmail,
                    Fechaalta = NewFechaalta,
                    Observaciones = NewObservaciones,
                    Telefono = NewTelefono
                };

                if (rep.AddCliente(cliente))
                {
                    Missatge = "El cliente se ha añadido correctamente.";
                }
                else
                {
                    Missatge = "El cliente no se ha podido añadir correctamente.";
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
