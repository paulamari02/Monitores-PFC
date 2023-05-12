using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace MonitoresTFC.Components
{
    public partial class MonitorsHeader
    {
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public string Title2 { get; set; } = string.Empty;
        public void GoMenu()
        {
            Nav.NavigateTo("/", true);
        }
    }
}
