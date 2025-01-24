using MauiApp1.Models;
using Newtonsoft.Json;

namespace MauiApp1
{
    public partial class ChecklistPage : ContentPage
    {
        private readonly ApiService apiService = new ApiService();
        public List<Checklist> ChecklistItems { get; set; } = new List<Checklist>();

        public ChecklistPage()
        {
            InitializeComponent();
            //BindingContext = this;
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var url = ApiService.GetApiChecklistUrl();
            var data = await apiService.GetDataAsync(url);

            if (!string.IsNullOrEmpty(data))
            {
                var checklistData = JsonConvert.DeserializeObject<List<Checklist>>(data);

                if (checklistData != null && checklistData.Count > 0)
                {
                    ChecklistItems = checklistData;
                    listViewProjects.ItemsSource = ChecklistItems;
                    noChecklistLabel.IsVisible = false;
                }
                else
                {
                    noChecklistLabel.IsVisible = true;
                }
            }

            else
            {
                noChecklistLabel.IsVisible = true;
            }
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Checklist checklistItemSelected)
            {
                await Navigation.PushAsync(new TasksPage(checklistItemSelected.Id));
            }
            else
            {
                await DisplayAlert("Error", "No item selected", "OK");
            }
        }
    }


}

