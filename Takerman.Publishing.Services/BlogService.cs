using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class BlogService(DefaultContext _context, IMapper _mapper) : IBlogService
    {
        public async Task<PublicationBlogpostDto> Create(PublicationBlogpostDto model)
        {
            var entity = _mapper.Map<PublicationBlogpost>(model);
            await _context.PublicationBlogposts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationBlogposts.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationBlogposts.Remove(entity);
            return true;
        }

        public async Task<PublicationBlogpostDto> Get(int id)
        {
            return await _context.PublicationBlogposts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationBlogpostDto>> GetAll(Project project)
        {
            var result = await _context.PublicationBlogposts
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationBlogpostDto>(x))
                .ToListAsync();

            return result;
        }

        public async Task<List<PublicationBlogpostDto>> Publish(PublicationBlogpostDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationBlogpostDto> Update(PublicationBlogpostDto publication)
        {
            var result = _context.PublicationBlogposts.Update((PublicationBlogpost)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}