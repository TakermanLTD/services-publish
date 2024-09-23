using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectPlatformsService
    {
        Task<ProjectPlatform> Get(int id);

        Task<ProjectPlatform> Get(int projectId, int platformId, int postTypeId);

        Task<List<ProjectPlatform>> GetAll();

        Task<List<ProjectPlatform>> GetAll(int projectId, int postTypeId);

        Task<ProjectPlatform> Create(ProjectPlatform model);

        Task<ProjectPlatform> Delete(ProjectPlatformSecretDto model);

        Task<ProjectPlatform> Update(ProjectPlatformSecretDto model);
    }
}