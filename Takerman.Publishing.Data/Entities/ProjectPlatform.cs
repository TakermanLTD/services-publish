using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatform
    {
        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;

        public string ClientUrl { get; set; } = string.Empty;

        [Key]
        public int Id { get; set; }

        public Platform Platform { get; set; }
        public PostType PostType { get; set; }
        public Project Project { get; set; }
    }
}