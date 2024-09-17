using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectPlatformsService(DefaultContext _context) : IProjectPlatformsService
    {
        public Task<ProjectPlatform> Get(int id)
        {
            return _context.ProjectPlatforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<ProjectPlatform>> GetAll()
        {
            return _context.ProjectPlatforms.ToListAsync();
        }

        public async Task<List<ProjectPlatform>> GetAll(int projectId, int postTypeId)
        {
            var result = await _context.ProjectPlatforms
                .Where(x => x.ProjectId == projectId && x.PostTypeId == postTypeId)
                .ToListAsync();

            return result;
        }

        public async Task<ProjectPlatform> Create(ProjectPlatform model)
        {
            var result = await _context.ProjectPlatforms.AddAsync(model);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<ProjectPlatform> Delete(int id)
        {
            var result = _context.ProjectPlatforms.Remove(await Get(id));
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Update(IEnumerable<ProjectPlatform> model)
        {
            _context.ProjectPlatforms.UpdateRange(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}