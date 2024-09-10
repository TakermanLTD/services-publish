using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class ProjectsService(DefaultContext _context, ILogger<ProjectsService> _logger) : IProjectsService
    {
        public Task<List<ProjectPlatform>> GetPlatforms(Project project, PostType postType)
        {
            return _context.ProjectPlatforms
                .Where(x => x.Project == project && x.PostType == postType)
                .ToListAsync();
        }

        public Task<List<ProjectPlatform>> GetPlatforms()
        {
            return _context.ProjectPlatforms
                .ToListAsync();
        }

        public async Task<ProjectPlatform> AddProjectPlatform(ProjectPlatformDto model)
        {
            var result = await _context.ProjectPlatforms.AddAsync(new ProjectPlatform()
            {
                PostType = model.PostType,
                Project = model.Project,
                ClientId = model.ClientId,
                ClientSecret = model.ClientSecret,
                ClientUrl = model.ClientUrl,
                Platform = model.Platform
            });

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteProjectPlatform(int id)
        {
            try
            {
                var projectPlatform = await _context.ProjectPlatforms.FirstOrDefaultAsync(x => x.Id == id);
                _context.ProjectPlatforms.Remove(projectPlatform);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting projectPlatform");
                return false;
            }
        }
    }
}