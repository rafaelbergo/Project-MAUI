using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using MauiApp1.Models;
using Newtonsoft.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiService apiService = new ApiService();
        public List<Checklist> ChecklistItems { get; set; } = new List<Checklist>();

        public MainPage()
        {
            InitializeComponent();
            //BindingContext = this;

            //LoadDataAsync();
        }
        
        private async void ChecklistButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChecklistPage());
        }
    }
}
