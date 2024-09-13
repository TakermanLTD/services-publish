using Newtonsoft.Json;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Data.DTOs
{
    public class ProjectPlatformDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("postType")]
        public PostType PostType { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        [JsonProperty("clientUrl")]
        public string ClientUrl { get; set; } = string.Empty;

        [JsonProperty("clientId")]
        public string ClientId { get; set; } = string.Empty;

        [JsonProperty("clientSecret")]
        public string ClientSecret { get; set; } = string.Empty;

        [JsonProperty("appsUrl")]
        public string AppsUrl { get; set; } = string.Empty;
    }
}