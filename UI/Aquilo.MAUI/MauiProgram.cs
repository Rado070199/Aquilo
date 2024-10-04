using Aquilo.MAUI.ViewModels;
using Aquilo.MAUI.Views;
using Microsoft.Extensions.Logging;

namespace Aquilo.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //VIEW MODELS
            builder.Services.AddTransient<StartViewModel>();
            //VIEWS
            builder.Services.AddTransient<StartView>();

            return builder.Build();
        }
    }
}
