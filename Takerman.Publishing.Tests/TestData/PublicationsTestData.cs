using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Tests.TestData
{
    public class PublicationsTestData
    {
        public PublicationBlogpostDto GetBlogpost()
        {
            return new PublicationBlogpostDto()
            {
                Platforms = new List<Platform>() { Platform.Wordpress, Platform.Blogger, Platform.Medium },
                PostDescription = "Test blogpost content",
                PostName = "Test blogpost"
            };
        }
    }
}