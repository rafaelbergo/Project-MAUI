using MauiApp1.Models;
using Newtonsoft.Json;

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
            var url = apiService.GetApiTaskUrl() + taskID;
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

        private void OnSavePopup(object sender, EventArgs e)
        {
            if (selectedTask != null)
            {
                // POST to update the task

                tasksProperties.IsVisible = false;
            }
        }

        private void OnClosePopup(object sender, EventArgs e)
        {
            tasksProperties.IsVisible = false;
        }
    }
}
