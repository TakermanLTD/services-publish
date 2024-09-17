using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Takerman.Publishing.Data.Entities
{
    public class PlatformLink
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual Platform Platform { get; set; }

        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }

        public string Url { get; set; } = string.Empty;
    }
}