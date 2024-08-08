using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;
using Takerman.Marketplace.Services.Dtos.Alobg;
using static System.Net.Mime.MediaTypeNames;

namespace Takerman.Marketplace.Services.Services
{
    public class AlobgService
    {
        public PlatformConfig Config { get; }

        private readonly HttpClient _httpClient;

        public AlobgService(HttpClient httpClient, IOptions<PlatformsConfig> options)
        {
            Config = options.Value.Platforms.First(x => x.Name.ToLower() == "alobg");
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(Config.Url);
        }

        public async Task Publish(PostDto post)
        {
            try
            {
                var data = new AlobgItemDto()
                {
                    Name = post.Name,
                    Description = post.Description,
                    Images = post.Pictures,
                    Price = post.Price
                };
                var dataJson = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, Application.Json);
                var result = await _httpClient.PostAsync(string.Format("import_info_api.php?username={0}&api_key={1}", Config.ClientId, Config.ClientSecret), dataJson);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}