using Takerman.Publishing.Data;
using Takerman.Publishing.Services.DTOs;

namespace Takerman.Publishing.Services
{
    public interface IProjectsService
    {
        Task<List<string>> GetProjectNames();

        Task<List<Project>> GetProjects();

        Task<List<ProjectPlatform>> GetPlatforms();

        Task<List<Platform>> GetPlatforms(int project, PostType postType);

        Task<ProjectPlatform> AddProjectPlatform(PlatformToProjectDto model);

        Task<bool> DeleteProjectPlatform(int id);

        Task<Project> AddProject(ProjectDto model);

        Task<bool> DeleteProject(int id);
    }
}