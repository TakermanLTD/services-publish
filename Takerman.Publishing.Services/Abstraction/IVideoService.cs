using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IVideoService
    {
        Task<PublicationVideoDto> Create(PublicationVideoDto model);

        Task<bool> Delete(int id);

        Task<PublicationVideoDto> Get(int id);

        Task<List<PublicationVideoDto>> GetAll(Project project);

        Task<List<PublicationVideoDto>> Publish(PublicationVideoDto publication);

        Task<PublicationVideoDto> Update(PublicationVideoDto publication);
    }
}