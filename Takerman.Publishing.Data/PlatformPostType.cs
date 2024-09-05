using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data
{
    public class PlatformPostType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int PlatformConfigDataId { get; set; }

        public virtual PlatformConfigData PlatformConfigData { get; set; } = new PlatformConfigData();

        public PostType PostType { get; set; }
    }
}