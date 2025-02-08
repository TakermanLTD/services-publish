using Microsoft.EntityFrameworkCore;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;

namespace Takerman.Publish.Services.Services
{
    public class ProjectsService(DefaultContext _context) : IProjectsService
    {
        public async Task<Project> Create(Project Project)
        {
            var result = await _context.Projects.AddAsync(Project);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var result = _context.Projects.Remove(await Get(id));

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<Project> Get(int id)
        {
            return _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> Update(Project Project)
        {
            var result = _context.Projects.Update(Project);

            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
