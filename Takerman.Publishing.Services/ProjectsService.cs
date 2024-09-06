using Microsoft.EntityFrameworkCore;
using System.Management;
using Takerman.Publishing.Data;

namespace Takerman.Publishing.Services
{
    public class ProjectsService(DefaultContext _context) : IProjectsService
    {
        public Task<List<string>> GetProjectNames()
        {
            return _context.Projects.Select(p => p.Name).ToListAsync();
        }

        public Task<List<Project>> GetProjects()
        {
            return _context.Projects.ToListAsync();
        }

        public async Task<List<Platform>> GetPlatforms(int project, PostType postType)
        {
            var result = await _context.PlatformsMappings
                .Include(x => x.PlatformConfigData)
                .Where(x => x.ProjectId == project && x.PostType == postType)
                .ToListAsync();

            return result.Select(x => x.PlatformConfigData.Platform).ToList();
        }

        public Task<List<ProjectPlatformsPosts>> GetPlatforms()
        {
            return _context.PlatformsMappings
                .Include(x => x.PlatformConfigData)
                .Include(x => x.Project)
                .ToListAsync();
        }
    }
}