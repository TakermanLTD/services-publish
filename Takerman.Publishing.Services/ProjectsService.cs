using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Abstraction;

namespace Takerman.Publishing.Services
{
    public class ProjectsService(DefaultContext _context, ILogger<ProjectsService> _logger, IMapper _mapper) : IProjectsService
    {
        public async Task<ProjectPlatformDto> AddProjectPlatform(ProjectPlatformDto model)
        {
            var entity = _mapper.Map<ProjectPlatform>(model);
            var result = await _context.ProjectPlatforms.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectPlatformDto>(result.Entity);
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

        public async Task<List<ProjectPlatformDto>> GetPlatforms(Project project, PostType postType)
        {
            var result = await _context.ProjectPlatforms
                .Where(x => x.Project == project && x.PostType == postType)
                .Select(x => _mapper.Map<ProjectPlatformDto>(x))
                .ToListAsync();

            foreach (var projectPlatform in result)
            {
                var links = await _context.PlatformLinks.Where(x => x.Platform == projectPlatform.Platform).ToListAsync();
                foreach (var link in links)
                    projectPlatform.PlatformLinks.Add(_mapper.Map<PlatformLinkDto>(link));
            }
            return result;
        }

        public Task<List<ProjectPlatformDto>> GetPlatforms()
        {
            return _context.ProjectPlatforms
                .Select(x => _mapper.Map<ProjectPlatformDto>(x))
                .ToListAsync();
        }

        public async Task<List<ProjectPlatformDto>> UpdateProjectPlatforms(IEnumerable<ProjectPlatform> model)
        {
            _context.ProjectPlatforms.UpdateRange(model);
            await _context.SaveChangesAsync();

            return model.Select(x => _mapper.Map<ProjectPlatformDto>(x)).ToList();
        }
    }
}