namespace Takerman.Publishing.Services.DTOs
{
    public class PublishVideoDto
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostVideo { get; set; }
    }
}