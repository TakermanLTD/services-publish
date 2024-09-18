using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectPlatformRecordService(DefaultContext _context) : IProjectPlatformRecordService
    {
        public async Task<ProjectPlatformRecord> Create(ProjectPlatformRecord ProjectPlatformRecord)
        {
            var result = await _context.ProjectPlatformRecords.AddAsync(ProjectPlatformRecord);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ProjectPlatformRecord> Delete(int id)
        {
            var result = _context.ProjectPlatformRecords.Remove(await Get(id));

            return result.Entity;
        }

        public Task<ProjectPlatformRecord> Get(int id)
        {
            return _context.ProjectPlatformRecords.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProjectPlatformRecord>> GetAll()
        {
            return await _context.ProjectPlatformRecords.ToListAsync();
        }

        public async Task<List<ProjectPlatformRecord>> GetAll(int projectPlatformId)
        {
            return await _context.ProjectPlatformRecords.Where(x => x.ProjectPlatformId == projectPlatformId).ToListAsync();
        }

        public async Task<ProjectPlatformRecord> Update(ProjectPlatformRecord ProjectPlatformRecord)
        {
            var result = _context.ProjectPlatformRecords.Update(ProjectPlatformRecord);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
