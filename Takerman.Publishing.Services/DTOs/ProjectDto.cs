using Newtonsoft.Json;

namespace Takerman.Publishing.Services.DTOs
{
    public class ProjectDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}