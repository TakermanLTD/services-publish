namespace Takerman.Publishing.Services.DTOs
{
    public class PublishTweetDto
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }
    }
}