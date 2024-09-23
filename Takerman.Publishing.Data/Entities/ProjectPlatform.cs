using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatform
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("ProjectPlatform_PlatformId")]
        public int PlatformId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Platform Platform { get; set; }

        [ForeignKey("ProjectPlatform_PostTypeId")]
        public int PostTypeId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PostType PostType { get; set; }

        [ForeignKey("ProjectPlatform_ProjectId")]
        public int ProjectId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Project Project { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public ICollection<ProjectPlatformSecret> PlatformSecrets { get; set; } = [];
    }
}