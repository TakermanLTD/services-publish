using System.Data.Entity;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;

namespace Takerman.Publishing.Services.Services
{
    public class ProjectService(DefaultContext _context) : IProjectService
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

            return result.Entity;
        }

        public Task<Project> Get(int id)
        {
            return _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Project>> GetAll()
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
