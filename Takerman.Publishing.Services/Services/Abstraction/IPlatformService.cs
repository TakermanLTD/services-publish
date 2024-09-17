using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPlatformService
    {
        Task<Platform> Get(int id);

        Task<IEnumerable<Platform>> GetAll();

        Task<Platform> Delete(int id);

        Task<Platform> Create(Platform platform);

        Task<Platform> Update(Platform platform);
    }
}
