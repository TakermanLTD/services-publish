using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IPlatformLinksService
    {
        Task<PlatformLinkDto> Create(PlatformLinkDto model);

        Task<bool> Delete(int id);

        Task<PlatformLinkDto> Get(int id);

        Task<List<PlatformLinkDto>> GetAll(Platform platform);

        Task<PlatformLinkDto> Update(PlatformLink platformLinks);

        Task<List<PlatformLinkDto>> Update(List<PlatformLinkDto> platformLinks);

        Task<List<PlatformLinkDto>> Update(List<PlatformLinkDto> platformLinks, Platform selectedPlatform);
    }
}