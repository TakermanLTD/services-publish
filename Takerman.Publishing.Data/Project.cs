using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}