using System.ComponentModel.DataAnnotations;

namespace Takerman.Publish.Data.Entities
{
    public class PostType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}