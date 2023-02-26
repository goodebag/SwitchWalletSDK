using Microsoft.Extensions.DependencyInjection;
using SwitchWalletSDK.Sdk.Models;
using SwitchWalletSDK.Sdk.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Services
{
    public static class Initialization
    {
        public static void AddSWitchWalletSdk(this IServiceCollection services, HttpClient httpClient,EnvironmentType environment = EnvironmentType.Sandbox)
        {
            services.AddHttpClient();
            RegisterServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            services.AddSingleton<IWalletServices>(x => new WalletServices(environment,httpClient));
        }
        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ISwitchWalletClient, SwitchWalletClient>();
        }
    }
}
