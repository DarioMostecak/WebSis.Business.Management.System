using Microsoft.AspNetCore.Components;


namespace WebSis.Buisness.Management.Warehause.Web.App.Views.Bases
{
    public partial class InputBase : ComponentBase
    {
        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public string Style { get; set; }

        public void SetPlaceholderValue(string value) =>
            this.Placeholder = value;
    }
}
