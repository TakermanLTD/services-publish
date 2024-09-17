using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPostTypeService
    {
        Task<PostType> Get(int id);

        Task<IEnumerable<PostType>> GetAll();

        Task<PostType> Delete(int id);

        Task<PostType> Create(PostType platform);

        Task<PostType> Update(PostType platform);
    }
}
