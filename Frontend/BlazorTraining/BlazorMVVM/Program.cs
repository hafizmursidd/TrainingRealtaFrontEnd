using BlazorMVVM;
using BlazorMVVM.Models;
using BlazorMVVM.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<FetchDataModel>();

builder.Services.AddTransient<FetchDataViewModel>();
builder.Services.AddTransient<CounterViewModel>();

builder.Services.AddTransient<IProductModel, ProductApiModel>();
builder.Services.AddTransient<ProductDataViewModel>();

builder.Services.AddTransient<IUserModel, UserApiModel>();
builder.Services.AddTransient<UserDataViewModel>();

await builder.Build().RunAsync();
