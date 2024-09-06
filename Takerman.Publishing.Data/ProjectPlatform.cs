using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data
{
    public class ProjectPlatform
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(PlatformData))]
        public int PlatformDataId { get; set; }

        public PostType PostType { get; set; }

        public virtual PlatformData AppPlatformData { get; set; }

        public virtual Project AppProject { get; set; }
    }
}