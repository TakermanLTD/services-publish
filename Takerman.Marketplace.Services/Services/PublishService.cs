using Microsoft.Extensions.Options;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Dtos;
using Takerman.Marketplace.Services.Dtos.Alobg;

namespace Takerman.Marketplace.Services.Services
{
    public class PublishService(IOptions<PlatformsConfig> _platformConfigs, AlobgService _alobgService) : IPublishService
    {
        public async Task<bool> PublishAsync(PostDto post)
        {
            var config = new PlatformConfig();

            foreach (var platform in post.Platforms)
            {
                switch (post.Type)
                {
                    case "Marketplaces":
                        switch (platform)
                        {
                            case "Alobg":
                                await _alobgService.Publish(post);
                                break;

                            case "Amazon":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "OLX":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "Bazar":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "Ebay":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "Etsy":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;
                        }
                        break;

                    case "Social":
                        switch (platform)
                        {
                            case "Facebook":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "Instagram":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "LinkedIn":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "TikTok":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;
                        }
                        break;

                    case "Bloggin":
                        switch (platform)
                        {
                            case "Medium":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;

                            case "Blogging":
                                config = _platformConfigs.Value.Platforms.First(x => x.Name.ToLower() == platform.ToLower());
                                break;
                        }
                        break;
                }
            }
            return true;
        }
    }
}