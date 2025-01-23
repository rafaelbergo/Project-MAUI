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
        int count = 0;
        private readonly ApiService apiService = new ApiService();
        public List<Checklist> ChecklistItems { get; set; } = new List<Checklist>();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var url = apiService.GetApiBaseUrl();
            var data = await apiService.GetDataAsync(url);

            if (!string.IsNullOrEmpty(data))
            {
                var checklistData = JsonConvert.DeserializeObject<List<Checklist>>(data);

                if (checklistData != null)
                {
                    ChecklistItems = checklistData;
                    listViewProjetos.ItemsSource = ChecklistItems;
                }
            }
        }
    }
}
