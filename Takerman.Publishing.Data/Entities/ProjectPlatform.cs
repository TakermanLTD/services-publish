using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatform
    {
        [Key]
        public int Id { get; set; }

        public Project Project { get; set; }

        public PostType PostType { get; set; }

        public Platform Platform { get; set; }

        public string ClientUrl { get; set; } = string.Empty;

        public string ClientId { get; set; } = string.Empty;

        public string ClientSecret { get; set; } = string.Empty;
    }
}