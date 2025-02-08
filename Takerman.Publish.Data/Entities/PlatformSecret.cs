using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publish.Data.Entities
{
    public class PlatformSecret
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [ForeignKey("PlatformSecret_PlatformId")]
        public int PlatformId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Platform Platform { get; set; }
    }
}
