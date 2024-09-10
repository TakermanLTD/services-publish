using Newtonsoft.Json;

namespace Takerman.Publishing.Data.DTOs
{
    public class ProjectPlatformDto
    {
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

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}