using Microsoft.Extensions.Configuration;

namespace MauiApp1
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public App()
        {
            InitializeComponent();

            Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            if (Current != null)
            {
                //Current.UserAppTheme = AppTheme.Dark;
                //Current.UserAppTheme = AppTheme.Light;
            }

            MainPage = new AppShell();
        }
    }
}
