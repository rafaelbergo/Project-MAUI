using MauiApp1.Models;
using Newtonsoft.Json;
using Microsoft.Maui.Devices;

namespace MauiApp1
{
    public partial class TasksPage : ContentPage
    {
        ApiService apiService = new ApiService();
        public List<MauiApp1.Models.Task> TaskItems { get; set; } = new List<MauiApp1.Models.Task>();
        private MauiApp1.Models.Task selectedTask;
        string taskID;

        public TasksPage(string itemID)
        {
            InitializeComponent();
            taskID = itemID;
            LoadDataAsync();
        }
        
        private async void LoadDataAsync()
        {
            var url = API.TASK_URL + taskID;
            var data = await apiService.GetDataAsync(url);

            if (!string.IsNullOrEmpty(data))
            {
                var taskData = JsonConvert.DeserializeObject<List<MauiApp1.Models.Task>>(data);

                if (taskData != null && taskData.Count > 0)
                {
                    TaskItems = taskData.OrderBy(task => task.OrderId).ToList();
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

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                selectedTask = e.Item as MauiApp1.Models.Task;

                if (selectedTask != null)
                {
                    labelName.Text = selectedTask.Name;
                    labelRelevantAspects.Text = selectedTask.RelevantAspects;
                    labelKeyPoint.Text = selectedTask.KeyPoint;
                    labelHowToDo.Text = selectedTask.HowToDo;
                    labelLocalCoordinates.Text = selectedTask.LocalCoordinates;

                    tasksProperties.IsVisible = true;
                }
                ((ListView)sender).SelectedItem = null;
            }
        }

        private async void OnSavePopup(object sender, EventArgs e)
        {
            if (selectedTask != null && !string.IsNullOrEmpty(labelLocalCoordinates.Text))
            {
                string taskId = selectedTask.Id;
                string newCoordinates = labelLocalCoordinates.Text;

                var isUpdated = await apiService.UptadeTaskProperty(taskId, newCoordinates);

                if (isUpdated)
                {
                    selectedTask.LocalCoordinates = newCoordinates;

                    labelLocalCoordinates.Text = newCoordinates;
                    await DisplayAlert("Success", "Coordinates updated", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Error to update", "OK");
                }

                tasksProperties.IsVisible = false;
            }

            else
            {
                await DisplayAlert("Error", "Coordinates empty", "OK");
            }
        }

        private void OnClosePopup(object sender, EventArgs e)
        {
            tasksProperties.IsVisible = false;
        }
    }
}
