using BlazorTraining;
using BlazorTraining.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using R_BlazorFrontEnd.Controls.Extensions;
using R_CommonFrontBackAPI;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.R_AddBlazorFrontEndControls();

R_ConfigurationUtility.Configure(builder.Configuration);

builder.Services.R_AddBlazorFrontMenu();

var host = builder.Build();

await host.R_UseBlazorFrontMenu();

await host.RunAsync();