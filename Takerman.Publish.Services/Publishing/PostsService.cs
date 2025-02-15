using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;
using Takerman.Publish.Services.Publishing.Abstraction;

namespace Takerman.Publish.Services.Publishing
{
    public class PostsService(DefaultContext _context, IMapper _mapper, IDistributedCache _cache) : IPostsService
    {
        private const string CacheKeyPrefix = "Post_";

        public async Task<PostDto> Create(Post model)
        {
            var entity = await _context.Posts.AddAsync(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDto>(entity.Entity);
        }

        public async Task<PostDto> Delete(int id)
        {
            var result = _context.Posts.Remove(await _context.Posts.FirstOrDefaultAsync(x => x.Id == id));
            await _context.SaveChangesAsync();
            await _cache.RemoveAsync(CacheKeyPrefix + id);
            return _mapper.Map<PostDto>(result.Entity);
        }

        public async Task<PostDto> Get(int id)
        {
            var cacheKey = CacheKeyPrefix + id;
            var cachedPost = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedPost))
            {
                return JsonConvert.DeserializeObject<PostDto>(cachedPost);
            }

            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            var postDto = _mapper.Map<PostDto>(post);

            if (postDto != null)
            {
                await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(postDto), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }

            return postDto;
        }

        public async Task<List<PostDto>> GetByProjectId(int projectId)
        {
            var posts = await _context.Posts.Where(p => p.ProjectId == projectId).ToListAsync();
            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<List<PostDto>> GetByProjectName(string projectName)
        {
            var posts = await _context.Posts.Where(p => p.Project.Name == projectName).ToListAsync();
            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<List<PostDto>> Publish(Post publication)
        {
            var result = await Create(publication);
            return new List<PostDto> { result };
        }

        public async Task<PostDto> Update(Post publication)
        {
            var result = _context.Posts.Update(publication);
            await _context.SaveChangesAsync();
            await _cache.RemoveAsync(CacheKeyPrefix + publication.Id);
            return _mapper.Map<PostDto>(result.Entity);
        }
    }
}