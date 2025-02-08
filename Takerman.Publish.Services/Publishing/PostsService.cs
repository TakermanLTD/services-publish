using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;
using Takerman.Publish.Services.Publishing.Abstraction;

namespace Takerman.Publish.Services.Publishing
{
    public class PostsService(DefaultContext _context, IMapper _mapper) : IPostsService
    {
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
            return _mapper.Map<PostDto>(result.Entity);
        }

        public async Task<PostDto> Get(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<PostDto>(post);
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
            return _mapper.Map<PostDto>(result.Entity);
        }
    }
}
