using Microsoft.AspNetCore.Components;


namespace WebSis.Buisness.Management.Warehause.Web.App.Views.Bases
{
    public partial class TextBoxBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string ValidationErrorMessage { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public string Type { get; set; }

        [Parameter]
        public string Style { get; set; }

        [Parameter]
        public List<(Func<string, bool>, string)> Validators { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public bool IsEnabled => IsDisabled is false;

        public async Task SetValue(string value)
        {
            this.Value = value;
            await ValueChanged.InvokeAsync(this.Value);
        }

        public void SetValidationErrorMessage(string message) =>
            this.ValidationErrorMessage = message;

        public void ClearErrorValidationMessage() =>
            this.ValidationErrorMessage = string.Empty;

        private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        {
            this.Value = changeEventArgs.Value.ToString();
            Validation(Validators);

            return ValueChanged.InvokeAsync(this.Value);
        }

        private void Validation(List<(Func<string, bool> condition, string message)> Validators)
        {
            foreach ((Func<string, bool> validator, string message) in Validators)
            {
                if (validator(this.Value))
                {
                    SetValidationErrorMessage(message);
                    return;
                }
            }
            ClearErrorValidationMessage();
        }

        public void Disable()
        {
            this.IsDisabled = true;
            InvokeAsync(StateHasChanged);
        }

        public void Enable()
        {
            this.IsDisabled = false;
            InvokeAsync(StateHasChanged);
        }
    }
}

