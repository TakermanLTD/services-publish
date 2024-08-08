using Microsoft.Extensions.Options;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;

namespace Takerman.Marketplace.Services.Services
{
    public interface IPublishService
    {
        Task<bool> PublishAsync(PostDto model, IOptions<PlatformsConfig> _platformConfigs);
    }
}