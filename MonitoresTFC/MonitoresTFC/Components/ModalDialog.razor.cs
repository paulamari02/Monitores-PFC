using Microsoft.AspNetCore.Components;

namespace MonitoresTFC.Components
{
    public partial class ModalDialog
    {
        public string ModalDisplay = "none;";
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public int Id { get; set; }
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public EventCallback<string> OnDelete { get; set; }
        public string ModalClass = "";
        public bool ShowModal
        {
            get;
            set;
        }
        [Parameter]
        public string ChildContent
        {
            get;
            set;
        }
        public async Task Delete()
        {
            await OnDelete.InvokeAsync(Name);
        }
        public void Close()
        {
            ModalDisplay = "none";
            ModalClass = "";
            StateHasChanged();
        }
        public void Show()
        {
            ModalDisplay = "block;";
            ModalClass = "Show";
            StateHasChanged();
        }
    }
}
