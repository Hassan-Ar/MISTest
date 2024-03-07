using Demo.RealestateApp.App1.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DemoRealestateApp.App1.Pages
{
   
    public partial class EditeProperty
    {
        public bool modalVisible = false; 
      
        public PropertyDetailVeiwModel prop = new PropertyDetailVeiwModel();

        public Task ShowModal()
        {
            modalVisible = true;
            return Task.CompletedTask;
        }

        private Task HideModal()
        {
            modalVisible = false;

            return Task.CompletedTask;
        }
    }
}
