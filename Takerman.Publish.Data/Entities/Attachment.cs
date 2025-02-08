using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Takerman.Publish.Data.Enums;

namespace Takerman.Publish.Data.Entities
{
    public class Attachment
    {
        [Key]
        public int Id { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Post Post { get; set; }

        [ForeignKey("Attachments_PostId")]
        public int PostId { get; set; }

        public AttachmentType Type { get; set; }

        public byte[] Data { get; set; } = [];
    }
}