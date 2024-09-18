using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class PlatformService(DefaultContext _context) : IPlatformService
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
