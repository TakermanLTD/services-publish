using System.ComponentModel.DataAnnotations;

namespace Takerman.Publish.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}