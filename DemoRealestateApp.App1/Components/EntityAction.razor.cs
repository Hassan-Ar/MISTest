using Blazorise;
using Microsoft.AspNetCore.Components;

namespace DemoRealestateApp.App1.Components
{
    public partial class EntityAction<TItem> : ComponentBase
    {
        public bool IsVisible = true;

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public bool Primary { get; set; }

        [Parameter]
        public EventCallback Clicked { get; set; }

        [Parameter]
        public string RequiredPolicy { get; set; }

        [Parameter]
        public Color Color { get; set; }


        [CascadingParameter]
        public EntityActions<TItem> ParentActions { get; set; } = new EntityActions<TItem>();


        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();
            IsVisible = true;
           
        }

        protected internal virtual async Task ActionClickedAsync()
        {
           await Clicked.InvokeAsync();
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            Color = Color.Primary;
            return ValueTask.CompletedTask;
        }
    }
}
