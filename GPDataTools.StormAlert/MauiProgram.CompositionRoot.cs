namespace GPDataTools.StormAlert;

using GPDataTools.StormAlert.Services;
using GPDataTools.StormAlert.ViewModels;

public static class StartupHelpers
{
    // Setup composition root (dependency injection graph)
    public static void SetupDependencies(this IServiceCollection services)
    {        
        services.AddScoped<BarometerService>();
        services.AddScoped<GpsService>();

        services.AddSingleton<MainPage>();

        // Our MainViewModel can be injected into the MainView for DataContext binding
        services.AddSingleton<MainViewModel>();
    }
}
