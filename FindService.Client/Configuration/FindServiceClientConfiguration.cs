using AuthenticationBase.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using System;
using System.Net.Http;
using TextService.Client;

namespace FindService.Client.Configuration
{
    public static class FindServiceClientConfiguration
    {
        public static IServiceCollection AddFindServiceClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddTransient(_ => RestService.For<IFindClient>(
                new HttpClient(
                new HttpClientHandler { ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true })
                {
                    BaseAddress = new Uri(configuration["ServiceUrls:FindService"]),                    
                    Timeout = TimeSpan.FromMinutes(5)
                }));
            
            return services;
        }

        public static IServiceCollection AddFindServiceTokenClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiClient<IFindClient>(configuration, new RefitSettings(), "ServiceUrls:FindService");

            return services;
        }
    }
}
