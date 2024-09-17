using Takerman.Publishing.Data.Entities;

namespace Takerman.Publishing.Services.Services.Abstraction
{
    public interface IPostService
    {
        Task<Post> Create(Post model);

        Task<Post> Delete(int id);

        Task<Post> Get(int id);

        Task<List<Post>> GetAll(int projectPlatformId);

        Task<List<Post>> Publish(Post publication);

        Task<Post> Update(Post publication);
    }
}