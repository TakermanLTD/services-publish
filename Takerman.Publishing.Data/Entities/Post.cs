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

        [ForeignKey("Post_ProjectPlatformId")]
        public int ProjectPlatfromId { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ProjectPlatform ProjectPlatform { get; set; }

        public DateTime DatePublished { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public IEnumerable<byte[]> Pictures { get; set; } = [];

        public IEnumerable<byte[]> Videos { get; set; } = [];

        public decimal Price { get; set; } = 0M;
    }
}
