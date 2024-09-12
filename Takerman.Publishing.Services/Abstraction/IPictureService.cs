using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IPictureService
    {
        Task<PublicationPictureDto> Create(PublicationPictureDto model);

        Task<bool> Delete(int id);

        Task<PublicationPictureDto> Get(int id);

        Task<List<PublicationPictureDto>> GetAll(Project project);

        Task<List<PublicationPictureDto>> Publish(PublicationPictureDto publication);

        Task<PublicationPictureDto> Update(PublicationPictureDto publication);
    }
}