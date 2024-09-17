using System.Text;

namespace Takerman.Publishing.Platforms.Olx
{
    public class OlxPlatform
    {
        public async Task GetTokenAsync()
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.olx.bg/open/oauth/token")
            {
                Content = new StringContent(
                "{\"grant_type\": \"\", \"client_id\": \"\", \"client_secret\": \"\", \"scope\": \"v2 read write\"}",
                Encoding.UTF8,
                "application/json")
            };

            var response = await client.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}