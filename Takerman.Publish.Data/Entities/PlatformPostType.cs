using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publish.Data.Entities
{
    public class PlatformPostType
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PlatformPostType_PlatformId")]
        public int PlatformId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Platform Platform { get; set; }

        [ForeignKey("PlatformPostType_PostTypeId")]
        public int PostTypeId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PostType PostType { get; set; }
    }
}
