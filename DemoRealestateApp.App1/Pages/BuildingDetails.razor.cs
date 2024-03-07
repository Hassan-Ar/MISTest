using Blazorise.DataGrid;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;
using Demo.RealestateApp1.App.ViewModels;
using DemoRealestateApp.App1.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace DemoRealestateApp.App1.Pages
{
    public partial class BuildingDetails
    {
        public List<BuildingViewModel> data { get; set; }
        [Inject]
        public IBuildingDataService BuildingDataService { get; set; }
        [Inject]
        public IProjectDataService projectDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public BuildingViewModel BuildingViewModel { get; set; }

        public DataGridEntityActionsColumn<BuildingViewModel> EntityActionsColumn = default!;
        public ObservableCollection<ProjectViewModel> projects { get; set; } = new ObservableCollection<ProjectViewModel>();
        public bool modalVisible = false;
        public string Message { get; set; }
        public string SelectedProjectId { get; set; }

        protected async override void OnInitialized()
        {
     
         //   data = await BuildingDataService.GetAllBuildings();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                data = await BuildingDataService.GetAllBuildings();
           
               //     Message = "Username/password combination unknown";
               //     StateHasChanged(); // Notify Blazor to re-render the component with the updated message
               
            }
        }

        protected async Task HandleValidSubmit()
        {
            BuildingViewModel.ProjectId = Guid.Parse(SelectedProjectId);
            ApiResponse<Guid> response;
            response = await BuildingDataService.Update(BuildingViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Property added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }

        public async Task OnReadData(DataGridReadDataEventArgs<BuildingViewModel> data)
        {
            var response = await BuildingDataService.GetAllBuildings();
            this.data = response;
            await InvokeAsync(StateHasChanged);
        }

        public virtual async Task DeleteRow(PropertyDetailVeiwModel row)
        {
            await BuildingDataService.Delete(row.Id.Value);
            await InvokeAsync(StateHasChanged);
        }

        public virtual async Task UpdateRow(PropertyDetailVeiwModel row)
        {
            await BuildingDataService.Delete(row.Id.Value);
            await InvokeAsync(StateHasChanged);
        }

        public Task ShowModal(BuildingViewModel var = null)
        {
            BuildingViewModel = var;
            modalVisible = true;
            return Task.CompletedTask;
        }

        private Task HideModal()
        {
            modalVisible = false;
            return Task.CompletedTask;
        }
        public void AddNewBuilding()
        {
            NavigationManager.NavigateTo("/BuildingEdite");
        }
        protected void Change(Guid id)
        {
            NavigationManager.NavigateTo($"/BuildingEdite/{id}");
        }
    }
}
