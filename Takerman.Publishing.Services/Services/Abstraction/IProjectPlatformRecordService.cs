using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectPlatformRecordService
    {
        Task<ProjectPlatformRecord> Get(int id);

        Task<IEnumerable<ProjectPlatformRecord>> GetAll(int projectPlatformId);

        Task<IEnumerable<ProjectPlatformRecord>> GetAll();

        Task<ProjectPlatformRecord> Delete(int id);

        Task<ProjectPlatformRecord> Create(ProjectPlatformRecord platform);

        Task<ProjectPlatformRecord> Update(ProjectPlatformRecord platform);
    }
}
