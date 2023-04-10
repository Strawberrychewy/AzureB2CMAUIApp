using AzureB2CMAUIApp.Services.LoginService;
using AzureB2CMAUIApp.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reflection;

namespace AzureB2CMAUIApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .IncludeFonts()
            .IncludeServices()
            .ManageConfigurations()
            .RegisterViewModels()
            .RegisterViews();

        RegisterRoutes();

		return builder.Build();
	}

    private static MauiAppBuilder IncludeFonts(this MauiAppBuilder builder) 
    {
        return builder.ConfigureFonts(fonts => {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
    }

    private static MauiAppBuilder IncludeServices(this MauiAppBuilder builder) 
    {
        builder.Services.AddSingleton<ILoginService, LoginService>();

        return builder;
    }

    public static MauiAppBuilder ManageConfigurations(this MauiAppBuilder builder) 
    {
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("AzureB2CMAUIApp.appsettings.json");

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();


        builder.Configuration.AddConfiguration(config);
        builder.Services.AddSingleton<IConfiguration>(config);
        return builder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder) 
    {
        mauiAppBuilder.Services.AddTransient<ViewModels.LoginPageViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder) 
    {
        mauiAppBuilder.Services.AddTransient<LoginPage>();
        mauiAppBuilder.Services.AddTransient<AppShell>();

        return mauiAppBuilder;
    }

    private static void RegisterRoutes() {
        Routing.RegisterRoute("login", typeof(LoginPage));
    }
}
