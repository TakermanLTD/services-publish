using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data
{
    public class ProjectPlatformsPosts
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = new Project();

        [ForeignKey(nameof(PlatformConfigData))]
        public int PlatformConfigDataId { get; set; }

        public virtual PlatformConfigData PlatformConfigData { get; set; } = new PlatformConfigData();

        public PostType PostType { get; set; }
    }
}