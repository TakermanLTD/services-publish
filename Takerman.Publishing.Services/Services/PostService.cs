using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class PostService(DefaultContext _context, IMapper _mapper) : IPostService
    {
        public async Task<Post> Create(Post model)
        {
            var entity = await _context.Posts.AddAsync(model);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<Post> Delete(int id)
        {
            var result = _context.Posts.Remove(await Get(id));
            
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<Post> Get(int id)
        {
            return _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Post>> GetAll(int projectPlatformId)
        {
            var result = await _context.Posts
                .Where(x => x.ProjectPlatfromId == projectPlatformId)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }

        public async Task<List<Post>> Publish(Post publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<Post> Update(Post publication)
        {
            var result = _context.Posts.Update(publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}