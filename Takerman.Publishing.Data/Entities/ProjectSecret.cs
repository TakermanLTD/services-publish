using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectSecret
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Value { get; set; } = string.Empty;

        [ForeignKey("ProjectSecret_PlatformId")]
        public int PlatformId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Platform Platform { get; set; }

        [ForeignKey("ProjectSecret_ProjectId")]
        public int ProjectId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Project Project { get; set; }

        [ForeignKey("ProjectSecret_PlatformSecretId")]
        public int PlatformSecretId { get; set; }
        
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PlatformSecret PlatformSecret { get; set; }
    }
}
