using Takerman.Publishing.Data.DTOs;

namespace Takerman.Publishing.Services.Abstraction
{
    public interface IBlogService
    {
        Task<PublicationBlogpostDto> Create(PublicationBlogpostDto model);

        Task<bool> Delete(int id);

        Task<PublicationBlogpostDto> Get(int id);

        Task<List<PublicationBlogpostDto>> GetAll(Project project);

        Task<List<PublicationBlogpostDto>> Publish(PublicationBlogpostDto publication);

        Task<PublicationBlogpostDto> Update(PublicationBlogpostDto publication);
    }
}