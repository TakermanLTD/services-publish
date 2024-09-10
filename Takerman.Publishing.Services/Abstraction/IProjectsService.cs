using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IProjectsService
    {
        Task<List<Platform>> GetPlatforms(int project, PostType postType);

        Task<List<ProjectPlatform>> GetPlatforms();

        Task<ProjectPlatform> AddProjectPlatform(PlatformToProjectDto model);

        Task<bool> DeleteProjectPlatform(int id);
    }
}