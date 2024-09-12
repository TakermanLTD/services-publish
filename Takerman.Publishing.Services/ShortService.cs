using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class ShortService(DefaultContext _context, IMapper _mapper) : IShortService
    {
        public async Task<PublicationShortDto> Create(PublicationShortDto model)
        {
            var entity = _mapper.Map<PublicationShort>(model);
            await _context.PublicationShorts.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationShorts.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationShorts.Remove(entity);
            return true;
        }

        public async Task<PublicationShortDto> Get(int id)
        {
            return await _context.PublicationShorts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationShortDto>> GetAll(Project project)
        {
            return await _context.PublicationShorts
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationShortDto>(x))
                .ToListAsync();
        }

        public async Task<List<PublicationShortDto>> Publish(PublicationShortDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationShortDto> Update(PublicationShortDto publication)
        {
            var result = _context.PublicationShorts.Update((PublicationShort)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}