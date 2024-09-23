using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class ProjectPlatformSecret
    {
        [Key]
        public int Id { get; set; }

        public string Value { get; set; } = string.Empty;

        [ForeignKey("ProjectPlatformSecret_ProjectPlatformId")]
        public int ProjectPlatformId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ProjectPlatform ProjectPlatform { get; set; }

        [ForeignKey("ProjectPlatformSecret_PlatformSecretId")]
        public int PlatformSecretId { get; set; }
        
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PlatformSecret PlatformSecret { get; set; }
    }
}
