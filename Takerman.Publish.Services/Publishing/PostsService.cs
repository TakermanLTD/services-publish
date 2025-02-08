using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class PostsService(DefaultContext _context, IMapper _mapper) : IPostsService
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