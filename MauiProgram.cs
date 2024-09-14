using Microsoft.Extensions.Logging;
using MyLoginApp.ViewModels;
using MyLoginApp.Views;

namespace MyLoginApp
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

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<AboutPage>();
            builder.Services.AddSingleton<ContactPage>();

            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<ProductPageViewModel>();
            builder.Services.AddSingleton<AddProductPageViewModel>();



            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);

                handler.PlatformView.SetHintTextColor(Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.LightGray));
#endif

#if WINDOWS
                handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness
                {
                    Bottom = 0,
                    Top = 0,
                    Left = 0,
                    Right = 0,
                };
#endif

#if IOS || MACCATALYST
                 handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;               
#endif
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
