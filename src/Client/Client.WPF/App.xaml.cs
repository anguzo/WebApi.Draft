using System.IO;
using System.Windows;
using Client.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Wpf;

/// <summary>
///     Composition root of the app.
/// </summary>
public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        IServiceProvider serviceProvider = ConfigureServiceProvider(configuration);

        Resources[nameof(ViewModelLocator)] = serviceProvider.GetRequiredService<ViewModelLocator>();
    }

    private static IServiceProvider ConfigureServiceProvider(IConfiguration configuration)
    {
        ServiceCollection services = new();

        services.AddLogic(configuration);

        return services.BuildServiceProvider();
    }
}
