using AutoMapper;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class PublishService(DefaultContext _context, IMapper _mapper) : IPublishService
    {
        public async Task Publish(PublicationBlogpostDto model)
        {
            var data = _mapper.Map<PublicationBlogpost>(model);
            await _context.PublicationBlogposts.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Publish(PublicationPictureDto model)
        {
            var data = _mapper.Map<PublicationPicture>(model);
            await _context.PublicationPictures.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Publish(PublicationSellingDto model)
        {
            var data = _mapper.Map<PublicationSelling>(model);
            await _context.PublicationSellings.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Publish(PublicationShortDto model)
        {
            var data = _mapper.Map<PublicationShort>(model);
            await _context.PublicationShorts.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Publish(PublicationTweetDto model)
        {
            var data = _mapper.Map<PublicationTweet>(model);
            await _context.PublicationTweets.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task Publish(PublicationVideoDto model)
        {
            var data = _mapper.Map<PublicationVideo>(model);
            await _context.PublicationVideos.AddAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}