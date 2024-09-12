using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class VideoService(DefaultContext _context, IMapper _mapper) : IVideoService
    {
        public async Task<PublicationVideoDto> Create(PublicationVideoDto model)
        {
            var entity = _mapper.Map<PublicationVideo>(model);
            await _context.PublicationVideos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationVideos.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationVideos.Remove(entity);
            return true;
        }

        public async Task<PublicationVideoDto> Get(int id)
        {
            return await _context.PublicationVideos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationVideoDto>> GetAll(Project project)
        {
            return await _context.PublicationVideos
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationVideoDto>(x))
                .ToListAsync();
        }

        public async Task<List<PublicationVideoDto>> Publish(PublicationVideoDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationVideoDto> Update(PublicationVideoDto publication)
        {
            var result = _context.PublicationVideos.Update((PublicationVideo)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}