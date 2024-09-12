using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class SellingService(DefaultContext _context, IMapper _mapper) : ISellingService
    {
        public async Task<PublicationSellingDto> Create(PublicationSellingDto model)
        {
            var entity = _mapper.Map<PublicationSelling>(model);
            await _context.PublicationSellings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PublicationSellings.FirstOrDefaultAsync(x => x.Id == id);
            _context.PublicationSellings.Remove(entity);
            return true;
        }

        public async Task<PublicationSellingDto> Get(int id)
        {
            return await _context.PublicationSellings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PublicationSellingDto>> GetAll(Project project)
        {
            return await _context.PublicationSellings
                .Where(x => x.ProjectId == (int)project)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PublicationSellingDto>(x))
                .ToListAsync();
        }

        public async Task<List<PublicationSellingDto>> Publish(PublicationSellingDto publication)
        {
            var result = await Create(publication);
            return [result];
        }

        public async Task<PublicationSellingDto> Update(PublicationSellingDto publication)
        {
            var result = _context.PublicationSellings.Update((PublicationSelling)publication);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}