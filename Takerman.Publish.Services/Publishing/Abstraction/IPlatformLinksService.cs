using Takerman.Publish.Data.Entities;

namespace Takerman.Publish.Services.Services.Abstraction
{
    public interface IPlatformLinksService
    {
        Task<PlatformLink> Create(PlatformLink model);

        Task<bool> Delete(int id);

        Task<PlatformLink> Get(int id);

        Task<List<PlatformLink>> GetAll(int platformID);

        Task<PlatformLink> Update(PlatformLink platformLinks);

        Task<bool> Update(List<PlatformLink> platformLinks);

        Task<bool> Update(List<PlatformLink> platformLinks, Platform selectedPlatform);
    }
}