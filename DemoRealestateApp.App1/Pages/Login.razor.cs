using Demo.RealestateApp.App1.Contracts;
using DemoRealestateApp.App1.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DemoRealestateApp.App1.Pages
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public async Task Login1()
        {
            var success = await AuthenticationService.Login(LoginViewModel.Email, LoginViewModel.Password);
            if (success)
            {
                NavigationManager.NavigateTo("/dashboard");
            }
            else
            {
                throw new Exception("asd");
            }
        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            //if (await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password))
            //{
            //    NavigationManager.NavigateTo("/");
            //}
            Message = "Username/password combination unknown";
        }
    }
}
