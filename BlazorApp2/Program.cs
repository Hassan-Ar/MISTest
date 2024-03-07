using BlazorApp2;
using BlazorApp2.Authentications;
using BlazorApp2.Contracts;
using BlazorApp2.Service;
using BlazorApp2.Service.Base;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://localhost:44318")
});

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<IPropertyDataService, PropertyDataService>();
builder.Services.AddScoped<IBuildingDataService, BuildingDataService>();
builder.Services.AddScoped<IProjectDataService, ProjectDataService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

await builder.Build().RunAsync();