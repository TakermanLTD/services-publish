using System.ComponentModel.DataAnnotations;

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
    }
}
