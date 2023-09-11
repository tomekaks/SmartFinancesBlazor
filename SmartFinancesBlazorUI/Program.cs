using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SmartFinancesBlazorUI;
using SmartFinancesBlazorUI.Contracts;
using SmartFinancesBlazorUI.Providers;
using SmartFinancesBlazorUI.Services;
using SmartFinancesBlazorUI.Services.Base;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7146"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ITransfersService, TransfersService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IBudgetPlannerService, BudgetPlannerService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
