namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationShortDto : IPublication
    {
        public PostType Type { get; } = PostType.Short;

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostShort { get; set; }
    }
}