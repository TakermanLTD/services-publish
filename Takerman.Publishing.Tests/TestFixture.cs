using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Takerman.Mail;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.Abstraction;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publishing.Tests
{
    public class TestFixture : TestBedFixture
    {
        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
            => services
                .AddTransient<IProjectsService, ProjectsService>()
                .AddTransient<IPublishService, PublishService>()
                .Configure<RabbitMqConfig>(options => configuration.GetSection(nameof(RabbitMqConfig)).Bind(options));

        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            yield return new() { Filename = "test-appsettings.json", IsOptional = false };
        }
    }
}