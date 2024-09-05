using System.ComponentModel.DataAnnotations;

namespace Takerman.Publishing.Data
{
    public class PlatformConfigData : PlatformConfig
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}