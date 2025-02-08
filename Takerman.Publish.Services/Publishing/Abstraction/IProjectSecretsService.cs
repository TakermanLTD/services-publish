using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;

namespace Takerman.Publish.Services.Services.Abstraction
{
    public interface IProjectSecretsService
    {
        Task<List<ProjectSecret>> Get(int projectId);

        Task<List<ProjectSecret>> Get(int projectId, int platformId);

        Task<List<ProjectSecret>> Delete(ProjectSecretDto model);

        Task<List<ProjectSecret>> Update(ProjectSecretDto model);

        Task<ProjectSecret> Create(ProjectSecret model);
    }
}
