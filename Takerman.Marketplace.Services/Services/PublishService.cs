using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;
using Takerman.Marketplace.Services.Dtos.Alobg;
using Takerman.Marketplace.Services.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Takerman.Marketplace.Services.Services
{
    public class PublishService(IOptions<PlatformsConfig> _platformConfigs, HttpClient _httpClient, ILogger<PublishService> _logger) : IPublishService
    {
        public async Task<bool> PublishAsync(PostDto post)
        {
            foreach (var platform in post.Platforms)
            {
                try
                {
                    var query = GetQuery(platform);
                    var data = GetJsonData(platform, post);
                    var result = await _httpClient.PostAsync(query, data);
                    return result.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception when publishing");
                }
            }

            return false;
        }

        private string GetQuery(Platform platform)
        {
            var config = _platformConfigs.Value.Platforms.First(x => x.Name == Enum.GetName(typeof(Platform), platform));

            _httpClient.BaseAddress = new Uri(config.Url);

            var result = string.Empty;

            switch (platform)
            {
                case Platform.Alobg:
                    result = string.Format("import_info_api.php?username={0}&api_key={1}", config.ClientId, config.ClientSecret);
                    break;

                case Platform.Amazon:
                    break;

                case Platform.OLX:
                    break;

                case Platform.Bazar:
                    break;

                case Platform.Ebay:
                    break;

                case Platform.Etsy:
                    break;

                case Platform.Facebook:
                    break;

                case Platform.Instagram:
                    break;

                case Platform.LinkedIn:
                    break;

                case Platform.TikTok:
                    break;

                case Platform.Medium:
                    break;

                case Platform.Blogger:
                    break;

                default:
                    break;
            }

            return result;
        }

        private StringContent GetJsonData(Platform type, PostDto post)
        {
            var data = new object();

            switch (type)
            {
                case Platform.Alobg:
                    data = new AlobgItemDto(post);
                    break;

                case Platform.Amazon:
                    break;

                case Platform.OLX:
                    break;

                case Platform.Bazar:
                    break;

                case Platform.Ebay:
                    break;

                case Platform.Etsy:
                    break;

                case Platform.Facebook:
                    break;

                case Platform.Instagram:
                    break;

                case Platform.LinkedIn:
                    break;

                case Platform.TikTok:
                    break;

                case Platform.Medium:
                    break;

                case Platform.Blogger:
                    break;
            }

            var json = JsonSerializer.Serialize(data);

            return new StringContent(json, Encoding.UTF8, Application.Json); ;
        }
    }
}