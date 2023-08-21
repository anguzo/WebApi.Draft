using Client.Logic;
using Client.Logic.OpenAPIs;
using Client.Logic.Services;
using Client.Logic.ViewModels;
using Microsoft.Extensions.Configuration;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiClient(configuration)
            .AddServices()
            .AddViewModels();

        return services;
    }

    private static IServiceCollection AddApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<IApiClient, ApiClient>()
            .ConfigureHttpClient(client =>
                client.BaseAddress = new Uri(configuration.GetConnectionString("ApiClientConnection") ??
                                             throw new InvalidOperationException(
                                                 "Api client connection string is not present in the configuration.")));

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<TodosService>();

        return services;
    }

    private static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<FirstUserControlViewModel>();

        services.AddSingleton<ViewModelLocator>();

        return services;
    }
}
