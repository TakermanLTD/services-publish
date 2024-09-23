using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IProjectsService
    {
        Task<Project> Get(int id);

        Task<List<Project>> GetAll();

        Task<Project> Delete(int id);

        Task<Project> Create(Project platform);

        Task<Project> Update(Project platform);
    }
}
