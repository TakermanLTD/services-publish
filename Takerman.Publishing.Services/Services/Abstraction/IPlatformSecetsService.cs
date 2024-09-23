using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPlatformSecetsService
    {
        Task<PlatformSecret> Get(int id);

        Task<List<PlatformSecret>> GetAll(int projectPlatformId);

        Task<List<PlatformSecret>> GetAll();

        Task<PlatformSecret> Delete(int id);

        Task<PlatformSecret> Create(PlatformSecret platform);

        Task<PlatformSecret> Update(PlatformSecret platform);
    }
}
