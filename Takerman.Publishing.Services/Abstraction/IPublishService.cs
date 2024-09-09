using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IPublishService
    {
        Task Publish(PublicationBlogpostDto model);

        Task Publish(PublicationPictureDto model);

        Task Publish(PublicationSellingDto model);

        Task Publish(PublicationShortDto model);

        Task Publish(PublicationTweetDto model);

        Task Publish(PublicationVideoDto model);
    }
}