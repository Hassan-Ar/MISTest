using Demo.RealestateApp.App.Contracts;
using Demo.RealestateApp.App.Service.Base;
using Microsoft.AspNetCore.Components;
using Demo.RealestateApp.App.ViewModels;
using System.Collections.ObjectModel;

namespace Demo.RealestateApp.App.Pages
{
    public partial class PropertyDetails
    {
        [Inject]
        public IPropertyDataService PropertyDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PropertyDetailVeiwModel PropertyViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            PropertyViewModel = new PropertyDetailVeiwModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await PropertyDataService.Create(PropertyViewModel);
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
    }
}
