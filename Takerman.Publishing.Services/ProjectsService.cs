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
                .Where(x => x.ProjectId == project && x.PostType == postType)
                .ToListAsync();

            return result.Select(x => x.Platform).ToList();
        }

        public Task<List<ProjectPlatform>> GetPlatforms()
        {
            return _context.ProjectPlatforms
                .Include(x => x.AppProject)
                .ToListAsync();
        }

        public async Task<ProjectPlatform> AddProjectPlatform(PlatformToProjectDto model)
        {
            var result = await _context.ProjectPlatforms.AddAsync(new ProjectPlatform()
            {
                PostType = (PostType)model.PostType,
                ProjectId = model.ProjectId,
                ClientId = model.ClientId,
                ClientSecret = model.ClientSecret,
                ClientUrl = model.ClientUrl,
                Platform = (Platform)model.Platform
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

        public async Task<Project> AddProject(ProjectDto model)
        {
            var result = await _context.Projects.AddAsync(new Project() { Name = model.Name });
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> DeleteProject(int id)
        {
            try
            {
                _context.Projects.Remove(await _context.Projects.FirstOrDefaultAsync(x => x.Id == id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting project");
                return false;
            }
        }
    }
}