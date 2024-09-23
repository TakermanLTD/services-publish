using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Dtos;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectSecretsService
    {
        Task<List<ProjectSecret>> Get(int projectId);

        Task<List<ProjectSecret>> Get(int projectId, int platformId);

        Task<List<ProjectSecret>> Delete(ProjectSecretDto model);
    }
}
