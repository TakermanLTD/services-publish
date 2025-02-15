namespace Takerman.Publish.Services.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime DatePublished { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public decimal Price { get; set; }

        public int ProjectId { get; set; }

        public int PostTypeId { get; set; }

        public string Thumbnail { get; set; }
    }
}