using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;
using Demo.RealestateApp1.App.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace DemoRealestateApp.App1.Pages
{
    public partial class CreateProperty
    {
        [Inject]
        public IPropertyDataService PropertyDataService { get; set; }
        [Inject]
        public ILogger<CreateProperty> Logger { get; set; }

        [Inject]
        public IBuildingDataService BuildingDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PropertyDetailVeiwModel propertyDetailViewModel { get; set; } = new PropertyDetailVeiwModel();
        public AddressViewModel address { get; set; } = new AddressViewModel();
        public ObservableCollection<BuildingViewModel> buildings { get; set; } = new ObservableCollection<BuildingViewModel>();


        public string Message { get; set; } = string.Empty;
        public string SelectedBuildingId { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            this.propertyDetailViewModel.ProductAddress = new AddressViewModel();
            var list = await BuildingDataService.GetAllBuildings();
            buildings = new ObservableCollection<BuildingViewModel>(list);
            if (buildings != null)
            {
                SelectedBuildingId = buildings.FirstOrDefault().Id.ToString();
            }
        }
        public async Task test()
        {
            var list = await BuildingDataService.GetAllBuildings();
            Logger.Log(LogLevel.Information, list.Select(x => x.ProductTitle).FirstOrDefault());
        }

        protected async Task HandleValidSubmit()
        {
            propertyDetailViewModel.BuildingId = Guid.Parse(SelectedBuildingId);
            ApiResponse<Guid> response;
            response = await PropertyDataService.Create(propertyDetailViewModel);
            HandleResponse(response);

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/PropertyDetails");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/PropertyDetails");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}

