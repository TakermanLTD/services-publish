using Takerman.Publish.Data.Entities;

namespace Takerman.Publish.Services.Services.Abstraction
{
    public interface IPlatformsService
    {
        Task<Platform> Get(int id);

        Task<List<Platform>> GetAll();

        Task<Platform> Delete(int id);

        Task<Platform> Create(Platform platform);

        Task<Platform> Update(Platform platform);
    }
}
