using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data.Entities
{
    public class PlatformLink : PlatformLinkDto
    {
        [Key]
        public int Id { get; set; }
    }
}