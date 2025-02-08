using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Takerman.Mail;
using Takerman.Publish.Data;
using Takerman.Publish.Data.Initialization;
using Takerman.Publish.Generation.Abstraction;
using Takerman.Publish.Server.Middleware;
using Takerman.Publish.Services.Platforms.YouTube;
using Takerman.Publish.Services.Publishing;
using Takerman.Publish.Services.Publishing.Abstraction;
using Takerman.Publish.Services.Services;
using Takerman.Publish.Services.Services.Abstraction;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publish.Tests
{
    public class TestFixture : TestBedFixture
    {
        private readonly string _dataAssembly;

        public TestFixture()
        {
            _dataAssembly = "Takerman.Publish.Data";
        }

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
            => services.AddDbContext<DefaultContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Takerman.Publish.Data")))
                .Configure<YouTubeConfig>(configuration.GetSection(nameof(YouTubeConfig)))
                .AddTransient<DbContext, DefaultContext>()
                .AddAutoMapper(Assembly.Load(_dataAssembly))
                .AddTransient<IPlatformsService, PlatformsService>()
                .AddTransient<IPlatformLinksService, PlatformLinksService>()
                .AddTransient<IPlatformPostTypesService, PlatformPostTypesService>()
                .AddTransient<IPlatformSecretsService, PlatformSecretsService>()
                .AddTransient<IProjectSecretsService, ProjectSecretsService>()
                .AddTransient<IPostsService, PostsService>()
                .AddTransient<IPostTypesService, PostTypesService>()
                .AddTransient<IProjectsService, ProjectsService>()
                .AddTransient<IContextInitializer, ContextInitializer>()
                .AddSingleton<IMixGenerator, MixGenerator>()
                .AddSingleton<IYouTubeUploader, YouTubeUploader>()
                .AddExceptionHandler<BadRequestExceptionHandler>()
                .AddExceptionHandler<GlobalExceptionHandler>()
                .Configure<RabbitMqConfig>(configuration.GetSection(nameof(RabbitMqConfig)));

        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            var result = new List<TestAppSettings>()
            {
                new(){ Filename = "test-appsettings.json", IsOptional = false },
                new(){ Filename = "test-appsettings.Production.json", IsOptional = true }
            };

            return result;
        }
    }
}