using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatform
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }

        [ForeignKey(nameof(PostType))]
        public int PostTypeId { get; set; }

        public virtual PostType PostType { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}