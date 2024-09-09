using Newtonsoft.Json;

namespace Takerman.Publishing.Data.DTOs
{
    public class PlatformToProjectDto
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("postType")]
        public int PostType { get; set; }

        [JsonProperty("platform")]
        public int Platform { get; set; }

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