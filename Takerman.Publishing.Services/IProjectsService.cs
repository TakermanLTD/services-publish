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
        
        Task<ProjectPlatform> AddPlatformToProject(PlatformToProjectDto model);
        
        Task<bool> DeleteProjectToPlatform(int id);
    }
}