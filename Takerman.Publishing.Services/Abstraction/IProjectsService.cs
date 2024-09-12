using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IProjectsService
    {
        Task<List<ProjectPlatformDto>> GetPlatforms(Project project, PostType postType);

        Task<List<ProjectPlatformDto>> GetPlatforms();

        Task<ProjectPlatformDto> AddProjectPlatform(ProjectPlatformDto model);

        Task<List<ProjectPlatformDto>> UpdateProjectPlatforms(IEnumerable<ProjectPlatform> model);

        Task<bool> DeleteProjectPlatform(int id);
    }
}