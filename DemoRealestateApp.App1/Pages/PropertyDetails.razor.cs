using Blazorise.DataGrid;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using Demo.RealestateApp.App1.ViewModels;
using Demo.RealestateApp1.App.ViewModels;
using DemoRealestateApp.App1.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace DemoRealestateApp.App1.Pages
{
    public partial class PropertyDetails 
    {
        public List<PropertyDetailVeiwModel> data {  get; set; }
        [Inject]
        public IPropertyDataService PropertyDataService { get; set; }
        [Inject]
        public IBuildingDataService BuildingDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } 
        
        public PropertyDetailVeiwModel prop = new PropertyDetailVeiwModel();
        public PropertyDetailVeiwModel PropertyViewModel { get; set; }
        public PropertyDetailVeiwModel CreateProperty { get; set; }
        public DataGridEntityActionsColumn<PropertyDetailVeiwModel> EntityActionsColumn = default!;
        public ObservableCollection<BuildingViewModel> buildings { get; set; } = new ObservableCollection<BuildingViewModel>();
        public bool modalVisible = false;
        public string Message { get; set; }
        public string SelectedBuildingId { get; set; }

        protected async override void OnInitialized()
        {

            PropertyViewModel = new PropertyDetailVeiwModel();
            PropertyViewModel.ProductAddress = new AddressViewModel();
            PropertyViewModel.ImagesPath = new List<ImageViewModel>();
            this.PropertyViewModel.ProductAddress = new AddressViewModel();
            var list = await BuildingDataService.GetAllBuildings();
            buildings = new ObservableCollection<BuildingViewModel>(list);
        }

        protected async Task HandleValidSubmit()
        {
            PropertyViewModel.BuildingId = Guid.Parse(SelectedBuildingId);
            ApiResponse<Guid> response;
                 response = await PropertyDataService.Update(PropertyViewModel);
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
        
        public async Task OnReadData(DataGridReadDataEventArgs<PropertyDetailVeiwModel> data)
        {
            var response = await PropertyDataService.GetAllProperties();
            this.data = response;
            await InvokeAsync(StateHasChanged);
        }

        public virtual async Task DeleteRow(PropertyDetailVeiwModel row)
        {
            await PropertyDataService.Delete(row.Id.Value);
            await InvokeAsync(StateHasChanged);
        }

        public Task ShowModal(PropertyDetailVeiwModel var  = null )
        {
            if (var is not null)
            {
                PropertyViewModel = var;
            }
            else
            {
                CreateProperty = new PropertyDetailVeiwModel();
            }

            modalVisible = true;
            return Task.CompletedTask;
        }

        private Task HideModal()
        {
            modalVisible = false;   
            return Task.CompletedTask;
        }
        protected void AddNewProperty()
        {
            NavigationManager.NavigateTo("/CreatePropetry");
        }


    }
    
}
