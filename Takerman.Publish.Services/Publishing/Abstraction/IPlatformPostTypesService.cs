using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;

namespace Takerman.Publish.Services.Services.Abstraction
{
    public interface IPlatformPostTypesService
    {
        Task<PlatformPostType> Create(int platformId, int postTypeId);

        Task<bool> Delete(int id);

        Task<PlatformPostType> Get(int id);

        Task<List<PlatformPostType>> GetAll(int platformID);

        Task<List<Platform>> GetAvailable(int projectId, int postTypeId);

        Task<List<int>> Update(PlatformPostTypesDto PostTypes);
    }
}
