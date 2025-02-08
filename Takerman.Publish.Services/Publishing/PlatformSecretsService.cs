using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class PlatformSecretsService(ILogger<PlatformSecretsService> _logger, DefaultContext _context) : IPlatformSecretsService
    {
        public async Task<PlatformSecret> Create(PlatformSecret model)
        {
            var newSecret = new PlatformSecret()
            {
                Name = model.Name,
                PlatformId = model.PlatformId
            };

            var result = await _context.PlatformSecrets.AddAsync(newSecret);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PlatformSecret> Delete(int id)
        {
            var result = _context.PlatformSecrets.Remove(await Get(id));

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<PlatformSecret> Get(int id)
        {
            return _context.PlatformSecrets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PlatformSecret>> GetAll()
        {
            return await _context.PlatformSecrets.ToListAsync();
        }

        public async Task<List<PlatformSecret>> GetAll(int projectPlatformId)
        {
            return await _context.PlatformSecrets.Where(x => x.PlatformId == projectPlatformId).ToListAsync();
        }

        public async Task<PlatformSecret> Update(PlatformSecret ProjectPlatformRecord)
        {
            var result = _context.PlatformSecrets.Update(ProjectPlatformRecord);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}