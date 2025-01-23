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

            MainPage = new AppShell();
        }
    }
}
