using Domain.Interfaces.AppSettings;
using Domain.Interfaces.Requests;
using Infrastructure.Services.AppSettings;
using Infrastructure.Services.Requests;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Common;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {   
        //services.AddSingleton<IUtilFunctionsSingleton, UtilFunctionsSingleton>();

        //services.AddScoped<IAssumptionOperaRepository, AssumptionOperaRepository>();

        //services.AddTransient<ISAPBOMTPOriginalService, SAPBOMTPOriginalService>();
        services.AddTransient<IApiSettingsService, ApiSettingsService>();
        services.AddTransient<IExternalApiService, ExternalApiService>();

        return services;
    }
}
