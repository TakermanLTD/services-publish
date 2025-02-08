using Takerman.Publish.Data.Entities;

namespace Takerman.Publish.Services.Services.Abstraction
{
    public interface IPostTypesService
    {
        Task<PostType> Get(int id);

        Task<List<PostType>> GetAll();

        Task<PostType> Delete(int id);

        Task<PostType> Create(PostType platform);

        Task<PostType> Update(PostType platform);
    }
}
