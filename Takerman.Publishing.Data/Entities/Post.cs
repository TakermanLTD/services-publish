using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data.Entities
{
    public class Post
    {
        [Key]
        public virtual int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DatePublished { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public IEnumerable<byte[]> Pictures { get; set; } = [];

        public IEnumerable<byte[]> Videos { get; set; } = [];

        public decimal Price { get; set; } = 0M;
    }
}
