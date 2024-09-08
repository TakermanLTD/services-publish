namespace Takerman.Publishing.Services.DTOs
{
    public class PublishPictureDto
    {
        public int Type { get; set; }

        public IEnumerable<Platform> Platforms { get; set; }

        public string PostDescription { get; set; }

        public IEnumerable<byte[]> PostPictures { get; set; }
    }
}