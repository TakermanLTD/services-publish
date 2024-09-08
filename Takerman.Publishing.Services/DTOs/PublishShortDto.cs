namespace Takerman.Publishing.Services.DTOs
{
    public class PublishShortDto
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }

        public byte[] PostShort { get; set; }
    }
}