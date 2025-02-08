using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Dtos;

namespace Takerman.Publish.Services.Publishing.Abstraction
{
    public interface IPostsService
    {
        Task<PostDto> Create(Post model);

        Task<PostDto> Delete(int id);

        Task<PostDto> Get(int id);

        Task<List<PostDto>> GetByProjectId(int projectId);

        Task<List<PostDto>> GetByProjectName(string projectName);

        Task<List<PostDto>> Publish(Post publication);

        Task<PostDto> Update(Post publication);
    }
}