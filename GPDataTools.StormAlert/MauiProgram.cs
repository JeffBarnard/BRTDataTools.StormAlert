namespace GPDataTools.StormAlert;
using Microsoft.Maui.LifecycleEvents;
using GPDataTools.StormAlert.Services;

#if (ANDROID || MACCATALYST)
using DevExpress.Maui;
#endif

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
#if (ANDROID || MACCATALYST)
			.UseDevExpress()
#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		var services = builder.Services;

		// Setup composition root (dependency injection graph)
		services.SetupDependencies();
		
#if WINDOWS
        //services.AddSingleton<ITrayService, WinUI.TrayService>();
        services.AddSingleton<INotificationService, GPDataTools.StormAlert.Platforms.Windows.NotificationService>();
#elif ANDROID
		services.AddSingleton<INotificationService, GPDataTools.StormAlert.Platforms.Android.NotificationService>();		
#elif MACCATALYST
        //services.AddSingleton<ITrayService, MacCatalyst.TrayService>();
        services.AddSingleton<INotificationService, GPDataTools.StormAlert.Platforms.MacCatalyst.NotificationService>();
#endif

		return builder.Build();
	}
}
