using CommunityToolkit.Maui;
using GreenTrack.Handlers;
using GreenTrack.Services;
using GreenTrack.ViewModels;
using GreenTrack.ViewModels.Assets;
using GreenTrack.ViewModels.Register;
using GreenTrack.Views.Assets;
using GreenTrack.Views.Register;
using Microsoft.Extensions.Logging;

namespace GreenTrack
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Lato-Bold.ttf", "LatoBold");
                    fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
                    fonts.AddFont("FontAwesome.otf", "Awesome");
                });
            Environment.SetEnvironmentVariable("API_BASE_URI", "http://10.0.2.2:5007/api/");
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddSingleton<SessionService>();
            builder.Services.AddHttpClient<CarbonGoalsService>()
                .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();
            builder.Services.AddHttpClient<AssetService>()
                .AddHttpMessageHandler<AuthenticatedHttpClientHandler>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<CompleteInformationViewModel>();
            builder.Services.AddTransient<AssetsViewModel>();

            builder.Services.AddTransient<AuthenticatedHttpClientHandler>();
           

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CompleteInformation>();
            builder.Services.AddTransient<Assets>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
