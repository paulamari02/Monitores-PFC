namespace MonitoresTFC.Models.DTO
{
    public class MenuDTO
    {
        public string Title { get; set; } = "";
        public string Icon { get; set; } = "";
        public string LinkPage { get; set; } = "";
        public int Section { get; set; } = 0;

        public MenuDTO(string Title,string Icon, string LinkPage, int Section) 
        {
            this.Title = Title;
            this.Icon = Icon;
            this.LinkPage = LinkPage;
            this.Section = Section;
        }
    }
}
