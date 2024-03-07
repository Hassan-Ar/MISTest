using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace DemoRealestateApp.App1.Components
{
    public partial class EntityActions<TItem> : ComponentBase
    {
        protected readonly List<EntityAction<TItem>> Actions = new List<EntityAction<TItem>>();
        protected bool HasPrimaryAction => Actions.Any(t => t.Primary);
        protected EntityAction<TItem> PrimaryAction => Actions.FirstOrDefault(t => t.Primary);
        public ActionType Type => Actions.Count(t => t.IsVisible) > 1 ? ActionType.Dropdown : ActionType.Button;

        [Parameter]
        public Color ToggleColor { get; set; } = Color.Primary;

        [Parameter]
        public string ToggleText { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public DataGridEntityActionsColumn<TItem> EntityActionsColumn { get; set; }


        internal void AddAction(EntityAction<TItem> action)
        {
            Actions.Add(action);
            if (EntityActionsColumn != null)
            {
                EntityActionsColumn.Displayable = Actions.Any(t => t.IsVisible);
            }
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}