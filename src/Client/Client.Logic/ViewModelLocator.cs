using Client.Logic.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Logic;

/// <summary>
///     Abstract factory for view models that utilizes lazy resolution from service provider.
/// </summary>
public class ViewModelLocator
{
    private readonly IServiceProvider _serviceProvider;

    public ViewModelLocator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    ///     This constructor is intended for XAML initialization only. The actual ViewModelLocator instance should be resolved
    ///     via the IoC container in code-behind.
    /// </summary>
    public ViewModelLocator()
    {
        ServiceCollection services = new();

        _serviceProvider = services.BuildServiceProvider();
    }

    public FirstUserControlViewModel FirstUserControlViewModel =>
        _serviceProvider.GetRequiredService<FirstUserControlViewModel>();
}
