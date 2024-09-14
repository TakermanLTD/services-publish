using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IProjectsService
    {
        Task<ProjectPlatformDto> AddProjectPlatform(ProjectPlatformDto model);

        Task<bool> DeleteProjectPlatform(int id);

        Task<List<ProjectPlatformDto>> GetPlatforms(Project project, PostType postType);

        Task<List<ProjectPlatformDto>> GetPlatforms();

        Task<List<ProjectPlatformDto>> UpdateProjectPlatforms(IEnumerable<ProjectPlatform> model);
    }
}