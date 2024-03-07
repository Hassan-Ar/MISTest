using Blazored.LocalStorage;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service.Base;
using DemoRealestateApp.App1.Authentications;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace DemoRealestateApp.App1.Service
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly HttpClient _httpClient;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, HttpClient httpClient) : base(client, localStorage)
        {
            _httpClient = httpClient;
        }

        //public async Task<bool> Authenticate(string email, string password)
        //{
        //    try
        //    {
        //        AuthenticationRequest authenticationRequest = new AuthenticationRequest() { Email = email, Password = password };
        //        var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

        //        if (authenticationResponse.Token != string.Empty)
        //        {
        //            await _localStorage.SetItemAsync("token", authenticationResponse.Token);
        //            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
        //            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResponse.Token.ToString());
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Login(string email, string password)
        {
            // Call your backend API to authenticate user
            var loginModel = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44318/api/Account/authenticate", loginModel);
            //var headers_ = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.IEnumerable<string>>();
            //foreach (var item_ in response.Headers)
            //    headers_[item_.Key] = item_.Value;
            //if (response.Content != null && response.Content.Headers != null)
            //{
            //    foreach (var item_ in response.Content.Headers)
            //        headers_[item_.Key] = item_.Value;
            //}

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                string token = string.Empty;
                JsonSerializer.Deserialize<Dictionary<string, string>>(jsonResponse).TryGetValue("token", out token);
                await _localStorage.SetItemAsync("jwtToken", token);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44318/api/Property");
                request.Headers.Add("Authorization", string.Format($"Bearer {0}", token));
               var response2 =  await _httpClient.SendAsync(request);
               if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response2.Content.ReadAsStringAsync());
                }
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
