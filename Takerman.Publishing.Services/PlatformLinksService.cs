using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class PlatformLinksService(DefaultContext _context, IMapper _mapper) : IPlatformLinksService
    {
        public async Task<PlatformLinkDto> Create(PlatformLinkDto model)
        {
            var entity = _mapper.Map<PlatformLink>(model);
            await _context.PlatformLinks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PlatformLinks.FirstOrDefaultAsync(x => x.Id == id);
            _context.PlatformLinks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PlatformLinkDto> Get(int id)
        {
            return await _context.PlatformLinks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlatformLinkDto>> GetAll(Platform platform)
        {
            var result = await _context.PlatformLinks
                .Where(x => x.Platform == platform)
                .OrderBy(x => x.Id)
                .Select(x => _mapper.Map<PlatformLinkDto>(x))
                .ToListAsync();

            return result;
        }

        public async Task<Dictionary<Platform, IEnumerable<PlatformLinkDto>>> GetPlatformsWithLinks()
        {
            var result = new Dictionary<Platform, IEnumerable<PlatformLinkDto>>();

            var platforms = "Platform".GetEnumMembers();
            foreach (var platform in platforms)
            {
                var platformEnum = (Platform)platform.Key;
                var links = await GetAll(platformEnum);
                result.Add(platformEnum, links);
            }

            return result;
        }

        public async Task<PlatformLinkDto> Update(PlatformLink platformLinks)
        {
            var result = _context.PlatformLinks.Update(platformLinks);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<PlatformLinkDto>> Update(List<PlatformLinkDto> platformLinks)
        {
            _context.PlatformLinks.UpdateRange((IEnumerable<PlatformLink>)platformLinks);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<PlatformLinkDto>>(await _context.PlatformLinks.ToListAsync());
        }

        public async Task<List<PlatformLinkDto>> Update(List<PlatformLinkDto> platformLinks, Platform selectedPlatform)
        {
            _context.PlatformLinks.UpdateRange((IEnumerable<PlatformLink>)platformLinks);
            await _context.SaveChangesAsync();
            return _mapper.Map<List<PlatformLinkDto>>(await _context.PlatformLinks.Where(x => x.Platform == selectedPlatform).ToListAsync());
        }
    }
}