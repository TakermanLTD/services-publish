using Microsoft.EntityFrameworkCore;
using Takerman.Publishing.Data;
using Takerman.Publishing.Services.DTOs;

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
            var result = await _context.ProjectPlatforms
                .Include(x => x.AppPlatformData)
                .Where(x => x.ProjectId == project && x.PostType == postType)
                .ToListAsync();

            return result.Select(x => x.AppPlatformData.Platform).ToList();
        }

        public Task<List<ProjectPlatform>> GetPlatforms()
        {
            return _context.ProjectPlatforms
                .Include(x => x.AppProject)
                .Include(x => x.AppPlatformData)
                .ToListAsync();
        }

        public async Task<ProjectPlatform> AddPlatformToProject(PlatformToProjectDto model)
        {
            var platformConfig = await _context.PlatformsData.AddAsync(new PlatformData()
            {
                ClientId = model.ClientId,
                ClientSecret = model.ClientSecret,
                ClientUrl = model.ClientUrl,
                Limit = model.Limit,
                Platform = (Platform)model.Platform
            });

            await _context.SaveChangesAsync();

            var projectPlatform = await _context.ProjectPlatforms.AddAsync(new ProjectPlatform()
            {
                PostType = (PostType)model.PostType,
                ProjectId = model.ProjectId,
                AppPlatformData = platformConfig.Entity
            });

            await _context.SaveChangesAsync();

            return projectPlatform.Entity;
        }

        public async Task<bool> DeleteProjectToPlatform(int id)
        {
            try
            {
                var projectPlatform = await _context.ProjectPlatforms.FirstOrDefaultAsync(x => x.Id == id);
                _context.PlatformsData.Remove(_context.PlatformsData.FirstOrDefault(x => x.Id == projectPlatform.PlatformDataId));
                _context.ProjectPlatforms.Remove(projectPlatform);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}