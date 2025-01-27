namespace MauiApp1
{
    public partial class ThemeManager : ContentView
    {
        public ThemeManager()
        {
            InitializeComponent();
        }

        private void DarkThemeEnabled(object sender, ToggledEventArgs e)
        {
            if (Application.Current != null)
            {
                Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
            }
        }
    }
}
