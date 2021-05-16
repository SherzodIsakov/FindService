using AuthenticationBase.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;
using System;
using System.Net.Http;

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
                }));

            return services;
        }
        public static IServiceCollection AddFindServiceTokenClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiClient<IFindClient>(configuration, new RefitSettings(), "ServiceUrls:FindService");

            return services;
        }
        public static IServiceCollection AddFindServiceStaticTokenClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiClientBGWorker<IFindClient>(configuration, new RefitSettings(), "ServiceUrls:FindService");

            return services;
        }

        //public static IServiceCollection AddFindServiceGetTokenClient(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var refitSettings = new RefitSettings
        //    {
        //        AuthorizationHeaderValueGetter = () => new AuthService().GetToken(new LoginModel { Username = "QWE", Password = "QweAsd123!" })
        //    };
        //    services.AddApiClient<IFindClient>(configuration, refitSettings, "ServiceUrls:FindService");

        //    return services;
        //}
    }
}
