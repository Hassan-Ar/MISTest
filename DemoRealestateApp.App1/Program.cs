using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Demo.RealestateApp.App.Service;
using Demo.RealestateApp.App1.Contracts;
using Demo.RealestateApp.App1.Service;
using Demo.RealestateApp.App1.Service.Base;
using DemoRealestateApp.App1;
using DemoRealestateApp.App1.Authentications;

using DemoRealestateApp.App1.Profiles;
using DemoRealestateApp.App1.Service;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
})
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();
{
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddBlazoredLocalStorage();

    builder.Services.AddAuthorizationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


    //builder.Services.AddSingleton(new HttpClient
    //{
    //    BaseAddress = new Uri("https://localhost:44313")
    //});
    builder.Services.AddTransient<CustomAuthorizationMessageHandler>();
    builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:44318/"));//.AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
    builder.Services.AddScoped<IPropertyDataService, PropertyDataService>();
    builder.Services.AddScoped<IBuildingDataService, BuildingDataService>();
    builder.Services.AddScoped<IProjectDataService, ProjectDataService>();
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddAutoMapper(typeof(Mapping));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
