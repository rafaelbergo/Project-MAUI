using System.Net.Http;

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
            return App.Configuration["API:URL"] ?? string.Empty;
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
    }
}