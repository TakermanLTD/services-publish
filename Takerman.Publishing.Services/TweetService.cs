using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class TweetService(DefaultContext _context, IMapper _mapper) : ITweetService
    {
        public async Task<PublicationTweetDto> Create(PublicationTweetDto model)
        {
            var entity = _mapper.Map<PublicationTweet>(model);
            await _context.PublicationTweets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationTweets.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationTweets.Remove(entity);
            return true;
        }

        public async Task<PublicationTweetDto> Get(int id)
        {
            return await _context.PublicationTweets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationTweetDto>> GetAll(Project project)
        {
            return await _context.PublicationTweets
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationTweetDto>(x))
                .ToListAsync();
        }

        public async Task<List<PublicationTweetDto>> Publish(PublicationTweetDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationTweetDto> Update(PublicationTweetDto publication)
        {
            var result = _context.PublicationTweets.Update((PublicationTweet)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}