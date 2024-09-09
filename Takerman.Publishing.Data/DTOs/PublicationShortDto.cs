namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationShortDto : IPublication
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostShort { get; set; }
    }
}