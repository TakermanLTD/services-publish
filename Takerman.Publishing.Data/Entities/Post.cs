using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class Post
    {
        [Key]
        public virtual int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DatePublished { get; set; } = DateTime.Now;

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0M;

        [ForeignKey("Post_ProjectId")]
        public int ProjectId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Project Project { get; set; }

        [ForeignKey("Post_PostTypeId")]
        public int PostTypeId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PostType PostType { get; set; }
    }
}
