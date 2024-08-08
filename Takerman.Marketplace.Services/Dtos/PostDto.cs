namespace Takerman.Marketplace.Services.Dtos
{
    public class PostDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<string> Platforms { get; set; }

        public IEnumerable<string> Pictures { get; set; }
    }
}