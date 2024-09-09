using Newtonsoft.Json;

namespace Takerman.Publishing.Data.DTOs
{
    public class ProjectDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}