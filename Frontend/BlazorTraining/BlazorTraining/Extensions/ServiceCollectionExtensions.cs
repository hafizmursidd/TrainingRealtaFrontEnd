using BlazorClientHelper;
using Blazored.LocalStorage;
using BlazorTraining.Constants;
using BlazorTraining.JSInterop;
using BlazorTraining.Services;
using BlazorTraining.Shared;
using BlazorTraining.Shared.Tabs;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using R_APIClient;
using R_BlazorFrontEnd.Configurations;
using R_BlazorFrontEnd.Controls.Menu;
using R_BlazorFrontEnd.Interfaces;
using R_BlazorFrontEnd.State;
using R_ContextFrontEnd;
using System.Globalization;

namespace BlazorTraining.Extensions
{
    public static class ServiceCollectionExtensions
    {
        internal static IServiceCollection R_AddBlazorFrontMenu(this IServiceCollection services)
        {
            services.AddSingleton<R_ContextHeader>();

            services.AddSingleton<R_IMenuService, R_MenuTrainingService>();
            //services.AddSingleton<R_ILoginService, R_LoginService>();
            services.AddSingleton<R_AccessStateContainer>();
            services.AddSingleton<R_BlazorMenuJsInterop>();

            var loUrlSections = R_FrontConfig.R_GetServiceUrlSection();

            foreach (var loUrl in loUrlSections)
            {
                services.AddHttpClient(loUrl.ServiceUrlName, client =>
                {
                    client.BaseAddress = new Uri(loUrl.ServiceUrl);
                    client.Timeout = TimeSpan.FromMinutes(10);
                });
            }

            services.AddSingleton<IClientHelper, U_GlobalVar>();

            services.AddBlazoredLocalStorage();
            services.AddSingleton(typeof(R_ILocalizer<>), typeof(R_Localizer<>));

            services.AddSingleton<R_IMainBody, MainBody>();

            services.AddScoped<MenuTabSetTool>();

            return services;
        }

        internal static async Task R_UseBlazorFrontMenu(this WebAssemblyHost host)
        {
            var loContextHeader = host.Services.GetRequiredService<R_ContextHeader>();
            var loHttpClientFactory = host.Services.GetRequiredService<IHttpClientFactory>();
            var loUrlSections = R_FrontConfig.R_GetServiceUrlSection();

            foreach (var loUrl in loUrlSections)
            {
                var loHttpClient = loHttpClientFactory.CreateClient(loUrl.ServiceUrlName);
                //var loTokenRepository = host.Services.GetRequiredService<R_ITokenRepository>();

                //if (loUrl.ServiceUrlName.Equals("R_TokenServiceUrl", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    R_HTTPClient.R_CreateInstanceWithName(loUrl.ServiceUrlName, httpClient, poTokenRepository: loTokenRepository);
                //    continue;
                //}

                R_HTTPClient.R_CreateInstanceWithName(loUrl.ServiceUrlName, loHttpClient, loContextHeader);
            }

            var loLocalStorage = host.Services.GetRequiredService<ILocalStorageService>();
            var lcCulture = await loLocalStorage.GetItemAsStringAsync(StorageConstants.Culture);

            CultureInfo loCulture = new CultureInfo("en");
            if (!string.IsNullOrWhiteSpace(lcCulture))
                loCulture = new CultureInfo(lcCulture);

            CultureInfo.DefaultThreadCurrentCulture = loCulture;
            CultureInfo.DefaultThreadCurrentUICulture = loCulture;
            
            var loClientHelper = host.Services.GetRequiredService<IClientHelper>();
            loClientHelper.Set_UserId("CP");
            loClientHelper.Set_CompanyId("001");
        }
    }
}
