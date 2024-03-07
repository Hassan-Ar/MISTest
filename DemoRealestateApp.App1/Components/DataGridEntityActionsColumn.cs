using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.Extensions.Localization;

namespace DemoRealestateApp.App1.Components
{
    public class DataGridEntityActionsColumn<TItem> : DataGridColumn<TItem>
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetDefaultValuesAsync();
        }

        protected virtual ValueTask SetDefaultValuesAsync()
        {
            Width = "150px";
            Sortable = false;
            Field = typeof(TItem).GetProperties().First().Name;
            return ValueTask.CompletedTask;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

        }
    }
}
