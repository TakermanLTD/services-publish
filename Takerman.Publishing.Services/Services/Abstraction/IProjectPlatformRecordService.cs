using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectPlatformRecordService
    {
        Task<ProjectPlatformSecrets> Get(int id);

        Task<List<ProjectPlatformSecrets>> GetAll(int projectPlatformId);

        Task<List<ProjectPlatformSecrets>> GetAll();

        Task<ProjectPlatformSecrets> Delete(int id);

        Task<ProjectPlatformSecrets> Create(ProjectPlatformSecrets platform);

        Task<ProjectPlatformSecrets> Update(ProjectPlatformSecrets platform);
    }
}
