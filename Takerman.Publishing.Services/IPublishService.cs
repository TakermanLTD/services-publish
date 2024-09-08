using Takerman.Publishing.Services.DTOs;

namespace Takerman.Publishing.Services
{
    public interface IPublishService
    {
        Task Publish(PublishBlogpostDto model);

        Task Publish(PublishPictureDto model);

        Task Publish(PublishSellingDto model);

        Task Publish(PublishShortDto model);

        Task Publish(PublishTweetDto model);

        Task Publish(PublishVideoDto model);
    }
}