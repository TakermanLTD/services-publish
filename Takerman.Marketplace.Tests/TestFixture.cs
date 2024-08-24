using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Takerman.Marketplace.Services.Configuration;
using Takerman.Marketplace.Services.Services;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Marketplace.Tests
{
    public class TestFixture : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
        {
            services
                .Configure<CommonConfig>(options => configuration.GetSection(nameof(CommonConfig)).Bind(options))
                .AddTransient<IArtificialInteligenceService, ArtificialInteligenceService>()
                .AddTransient<IPublishService, PublishService>();
        }

        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "test-appsettings.json", IsOptional = false };
        }
    }
}