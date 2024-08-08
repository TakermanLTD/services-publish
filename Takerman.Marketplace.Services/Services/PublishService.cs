using Microsoft.Extensions.Options;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;

namespace Takerman.Marketplace.Services.Services
{
    public class PublishService : IPublishService
    {
        public async Task<bool> PublishAsync(PostDto model, IOptions<PlatformsConfig> platformConfigs)
        {
            return true;
        }
    }
}