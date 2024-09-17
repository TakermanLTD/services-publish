using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatformRecord
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Value { get; set; } = string.Empty;

        [ForeignKey(nameof(ProjectPlatform))]
        public int ProjectPlatformId { get; set; }

        public virtual ProjectPlatform ProjectPlatform { get; set; }
    }
}
