using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class PlatformLinksService(DefaultContext _context) : IPlatformLinksService
    {
        public async Task<PlatformLink> Create(PlatformLink model)
        {
            var newLink = new PlatformLink()
            {
                Name = model.Name,
                PlatformId = model.PlatformId,
                Url = model.Url
            };

            var result = await _context.PlatformLinks.AddAsync(newLink);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PlatformLinks.FirstOrDefaultAsync(x => x.Id == id);

            _context.PlatformLinks.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<PlatformLink> Get(int id)
        {
            return await _context.PlatformLinks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlatformLink>> GetAll(int platformID)
        {
            var result = await _context.PlatformLinks
                .Where(x => x.PlatformId == platformID)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return result;
        }

        public async Task<PlatformLink> Update(PlatformLink platformLinks)
        {
            var result = _context.PlatformLinks.Update(platformLinks);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Update(List<PlatformLink> platformLinks)
        {
            _context.PlatformLinks.UpdateRange(platformLinks);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(List<PlatformLink> platformLinks, Platform selectedPlatform)
        {
            _context.PlatformLinks.UpdateRange(platformLinks);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}