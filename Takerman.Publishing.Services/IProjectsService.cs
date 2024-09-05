using Takerman.Publishing.Data;

namespace Takerman.Publishing.Services
{
    public interface IProjectsService
    {
        Task<List<string>> GetProjectNames();

        Task<List<Project>> GetProjects();

        Task<List<Platform>> GetPlatforms(int project, PostType postType);
    }
}