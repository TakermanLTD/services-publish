using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IShortService
    {
        Task<PublicationShortDto> Create(PublicationShortDto model);

        Task<bool> Delete(int id);

        Task<PublicationShortDto> Get(int id);

        Task<List<PublicationShortDto>> GetAll(Project project);

        Task<List<PublicationShortDto>> Publish(PublicationShortDto publication);

        Task<PublicationShortDto> Update(PublicationShortDto publication);
    }
}