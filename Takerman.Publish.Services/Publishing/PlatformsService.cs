using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class PlatformsService(DefaultContext _context) : IPlatformsService
    {
        public async Task<Platform> Create(Platform platform)
        {
            var result = await _context.Platforms.AddAsync(platform);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Platform> Delete(int id)
        {
            var result = _context.Platforms.Remove(await Get(id));

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<Platform> Get(int id)
        {
            return _context.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Platform>> GetAll()
        {
            return _context.Platforms.Select(x => x).ToListAsync();
        }

        public async Task<Platform> Update(Platform platform)
        {
            var result = _context.Platforms.Update(platform);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
