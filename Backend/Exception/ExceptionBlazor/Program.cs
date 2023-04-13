using ExceptionBlazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using R_APIClient;
using R_ContextEnumAndInterface;
using R_ContextFrontEnd;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var host = builder.Build();

var httpClient = new HttpClient
{
    BaseAddress = new Uri("http://localhost:5285/")
};

R_HTTPClient.R_CreateInstanceWithName("DEFAULT", httpClient, null);


await host.RunAsync();

