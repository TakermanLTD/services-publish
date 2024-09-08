namespace Takerman.Publishing.Services.DTOs
{
    public class PublishSellingDto
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostName { get; set; }

        public string PostDescription { get; set; }

        public decimal PostPrice { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }

        public IEnumerable<byte[]> PostVideos { get; set; }
    }
}