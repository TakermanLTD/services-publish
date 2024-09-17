using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectPlatformsService
    {
        Task<ProjectPlatform> Get(int id);

        Task<List<ProjectPlatform>> GetAll();

        Task<List<ProjectPlatform>> GetAll(int projectId, int postTypeId);

        Task<ProjectPlatform> Create(ProjectPlatform model);

        Task<ProjectPlatform> Delete(int id);

        Task<bool> Update(IEnumerable<ProjectPlatform> model);
    }
}