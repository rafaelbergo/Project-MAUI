using MauiApp1.Models;
using Newtonsoft.Json;

namespace MauiApp1 { 

public partial class TasksPage : ContentPage
    {
        ApiService apiService = new ApiService();
        public List<MauiApp1.Models.Task> TaskItems { get; set; } = new List<MauiApp1.Models.Task>();
        string taskID;
        public TasksPage(string itemID)
        {
            InitializeComponent();
            taskID = itemID;
            LoadDataAsync();
        }
        private async void LoadDataAsync()
        {
            var url = apiService.GetApiTaskUrl() + taskID; 
            var data = await apiService.GetDataAsync(url);

            if (!string.IsNullOrEmpty(data))
            {
                var taskData = JsonConvert.DeserializeObject<List<MauiApp1.Models.Task>>(data);

                if (taskData != null && taskData.Count > 0)
                {
                    TaskItems = taskData;
                    listViewTasks.ItemsSource = TaskItems;
                    noTasksLabel.IsVisible = false;
                }
                else 
                {
                    noTasksLabel.IsVisible = true;
                }
            }

            else 
            {
                noTasksLabel.IsVisible = true;
            }
        }
    }
}