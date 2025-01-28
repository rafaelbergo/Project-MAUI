using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MauiApp1
{

    public class ApiService
    {
        private readonly HttpClient httpClient = new HttpClient();

        public ApiService()
        {

        }

        public string GetApiBaseUrl()
        {
            return App.Configuration["API:BASE_URL"] ?? string.Empty;
        }

        public static string GetApiChecklistUrl()
        {
            return App.Configuration["API:CHECKLIST_URL"] ?? string.Empty;
        }

        public string GetApiTaskUrl()
        {
            return App.Configuration["API:TASK_URL"] ?? string.Empty;
        }

        public static string PostTaskUrl()
        {
            return App.Configuration["API:POST_TASK_URL"] ?? string.Empty;
        }

        public async Task<string?> GetDataAsync(string url)
        {
            try
            {
                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }

            catch
            {
                return null;
            }
        }

        public async Task<bool> UptadeTaskProperty(string taskId, string localCoordinates)
        {
            var json = JsonConvert.SerializeObject(localCoordinates);

            var url = API.POST_TASK_URL + taskId + "/local-coordinates";
            var content = new StringContent(json, Encoding.UTF8, "text/json");

            var request = await httpClient.PostAsync(url, content);

            if (request.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}