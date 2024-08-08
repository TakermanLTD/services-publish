using Takerman.Marketplace.Services.Dtos;

namespace Takerman.Marketplace.Services.Services
{
    public interface IPublishService
    {
        Task<bool> PublishAsync(PostDto model);
    }
}