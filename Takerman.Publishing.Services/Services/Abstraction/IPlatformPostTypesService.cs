using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;

namespace Takerman.Publishing.Services.Services.Abstraction
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
