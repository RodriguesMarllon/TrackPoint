using Domain.Interfaces.AppSettings;
using Domain.Interfaces.Requests;
using Domain.InterfacesRepositories.Clients;
using Domain.InterfacesRepositories.Employees;
using Domain.InterfacesRepositories.Projects;
using Domain.InterfacesRepositories.WorkLogs;
using Infrastructure.Repositories.Clients;
using Infrastructure.Repositories.Employees;
using Infrastructure.Repositories.Projects;
using Infrastructure.Repositories.WorkLogs;
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

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IWorkLogRepository, WorkLogRepository>();

        //services.AddTransient<ISAPBOMTPOriginalService, SAPBOMTPOriginalService>();
        services.AddTransient<IApiSettingsService, ApiSettingsService>();
        services.AddTransient<IExternalApiService, ExternalApiService>();

        return services;
    }
}
