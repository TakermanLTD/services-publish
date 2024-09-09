using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class PublishService(DefaultContext _context) : IPublishService
    {
        public Task Publish(PublicationBlogpostDto model)
        {

            throw new NotImplementedException();
        }

        public Task Publish(PublicationPictureDto model)
        {
            throw new NotImplementedException();
        }

        public Task Publish(PublicationSellingDto model)
        {
            throw new NotImplementedException();
        }

        public Task Publish(PublicationShortDto model)
        {
            throw new NotImplementedException();
        }

        public Task Publish(PublicationTweetDto model)
        {
            throw new NotImplementedException();
        }

        public Task Publish(PublicationVideoDto model)
        {
            throw new NotImplementedException();
        }
    }
}