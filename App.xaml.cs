using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace MauiApp1
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public App()
        {
            InitializeComponent();
            /*
#if ANDROID
            var a = Assembly.GetExecutingAssembly();

            var appSettings = $"{a.GetName().Name}.Resources.appsettings.json";

            using var stream = a.GetManifestResourceStream(appSettings);

            if (stream != null)
            {
                var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            }
            
#else
                Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
#endif*/

            if (Current != null)
            {
                //Current.UserAppTheme = AppTheme.Dark;
                //Current.UserAppTheme = AppTheme.Light;
            }

            MainPage = new AppShell();
        }
    }
}
