namespace Takerman.Publishing.Data.DTOs
{
    public class PublicationVideoDto : IPublication
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostVideo { get; set; }
    }
}