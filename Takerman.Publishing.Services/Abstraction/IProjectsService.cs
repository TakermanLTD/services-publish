using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IProjectsService
    {
        Task<List<ProjectPlatform>> GetPlatforms(Project project, PostType postType);

        Task<List<ProjectPlatform>> GetPlatforms();

        Task<ProjectPlatform> AddProjectPlatform(ProjectPlatformDto model);

        Task<bool> DeleteProjectPlatform(int id);
    }
}