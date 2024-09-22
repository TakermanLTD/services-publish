using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectPlatformRecordService(DefaultContext _context) : IProjectPlatformRecordService
    {
        public async Task<ProjectPlatformSecrets> Create(ProjectPlatformSecrets ProjectPlatformRecord)
        {
            var result = await _context.ProjectPlatformSecrets.AddAsync(ProjectPlatformRecord);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ProjectPlatformSecrets> Delete(int id)
        {
            var result = _context.ProjectPlatformSecrets.Remove(await Get(id));

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<ProjectPlatformSecrets> Get(int id)
        {
            return _context.ProjectPlatformSecrets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectPlatformSecrets>> GetAll()
        {
            return await _context.ProjectPlatformSecrets.ToListAsync();
        }

        public async Task<List<ProjectPlatformSecrets>> GetAll(int projectPlatformId)
        {
            return await _context.ProjectPlatformSecrets.Where(x => x.ProjectPlatformId == projectPlatformId).ToListAsync();
        }

        public async Task<ProjectPlatformSecrets> Update(ProjectPlatformSecrets ProjectPlatformRecord)
        {
            var result = _context.ProjectPlatformSecrets.Update(ProjectPlatformRecord);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
