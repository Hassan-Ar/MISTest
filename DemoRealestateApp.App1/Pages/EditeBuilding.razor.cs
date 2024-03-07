using Blazorise.DataGrid;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;
using Demo.RealestateApp1.App.ViewModels;
using DemoRealestateApp.App1.Components;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace DemoRealestateApp.App1.Pages
{
    public partial class EditeBuilding
    {
        [Inject]
        public IBuildingDataService BuildingDataService { get; set; }
        [Inject]
        public IProjectDataService projectDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public BuildingViewModel BuildingViewModel { get; set; } = new BuildingViewModel();
        public AddressViewModel address { get; set; } = new AddressViewModel();

        public DataGridEntityActionsColumn<BuildingViewModel> EntityActionsColumn = default!;
        public ObservableCollection<ProjectViewModel> projects { get; set; } = new ObservableCollection<ProjectViewModel>();
        public string Message { get; set; }
        public string SelectedProjectId { get; set; }

        [Parameter]
        public string buildinginputID { get; set; }
        public Guid SelectedBuildingId = Guid.Empty;
        protected async override void OnInitialized()
        {
            BuildingViewModel = new BuildingViewModel();
            this.BuildingViewModel.ProductAddress = new AddressViewModel();
            var list = await projectDataService.GetAllProjects();
            projects = new ObservableCollection<ProjectViewModel>(list);
            if (Guid.TryParse(buildinginputID, out SelectedBuildingId))
            {
                try
                {
                    BuildingViewModel = await BuildingDataService.GetBuildingById(SelectedBuildingId);
                }
                catch (Exception ex)
                {
                    NavigationManager.NavigateTo("/BuildingDetails");
                }
            }

        }

        protected async Task HandleValidSubmit()
        {
            if (SelectedProjectId != null)
            {
                BuildingViewModel.ProjectId = Guid.Parse(SelectedProjectId);
            }
            ApiResponse<Guid> response;
            if (SelectedBuildingId == Guid.Empty)
            {
                response = await BuildingDataService.Create(BuildingViewModel);
            }
            else
            {
                response = await BuildingDataService.Update(BuildingViewModel);
            }

            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                Message = "Building Updated";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
            NavigationManager.NavigateTo("/BuildingDetails");

        }
        public async Task OnReadData(DataGridReadDataEventArgs<BuildingViewModel> data)
        {
            var response = await BuildingDataService.GetBuildingById(SelectedBuildingId);
            this.BuildingViewModel = response;
            await InvokeAsync(StateHasChanged);
        }
        public virtual async Task DeletePoduct(Guid id)
        {
            await BuildingDataService.Delete(id);
            await InvokeAsync(StateHasChanged);
        }
    }
}
