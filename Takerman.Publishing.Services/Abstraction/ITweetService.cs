using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface ITweetService
    {
        Task<PublicationTweetDto> Create(PublicationTweetDto model);

        Task<bool> Delete(int id);

        Task<PublicationTweetDto> Get(int id);

        Task<List<PublicationTweetDto>> GetAll(Project project);

        Task<List<PublicationTweetDto>> Publish(PublicationTweetDto publication);

        Task<PublicationTweetDto> Update(PublicationTweetDto publication);
    }
}