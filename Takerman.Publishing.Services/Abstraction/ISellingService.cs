using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface ISellingService
    {
        Task<PublicationSellingDto> Create(PublicationSellingDto model);

        Task<bool> Delete(int id);

        Task<PublicationSellingDto> Get(int id);

        Task<List<PublicationSellingDto>> GetAll(Project project);

        Task<List<PublicationSellingDto>> Publish(PublicationSellingDto publication);

        Task<PublicationSellingDto> Update(PublicationSellingDto publication);
    }
}