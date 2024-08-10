using Takerman.Marketplace.Services.Enums;

namespace Takerman.Marketplace.Services.Dtos
{
    public class PostDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public PlatformType Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; } = [];

        public IEnumerable<string> Pictures { get; set; } = [];
    }
}