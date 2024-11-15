using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Services;
using Polly;
using Polly.Extensions.Http;
using SmartFinancesBlazorUI;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Handlers;
using SmartFinancesBlazorUI.Providers;
using SmartFinancesBlazorUI.Services;
using SmartFinancesBlazorUI.Services.Base;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<JwtAuthorizationMessageHandler>();

var environment = builder.HostEnvironment.Environment;

if(environment == "Development")
{
    builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7146"))
        .AddHttpMessageHandler<JwtAuthorizationMessageHandler>()
        .AddPolicyHandler(GetRetryPolicy());
}
else
{
    builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://smartfinancesapi-tomekaks.azurewebsites.net/"))
        .AddHttpMessageHandler<JwtAuthorizationMessageHandler>()
        .AddPolicyHandler(GetRetryPolicy());
}

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
});

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ITransfersService, TransfersService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IBudgetPlannerService, BudgetPlannerService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAccountRequestService, AccountRequestService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IAccountTypesService, AccountTypesService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
