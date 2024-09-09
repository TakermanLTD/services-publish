using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Takerman.Mail;
using Takerman.Publishing.Data;
using Takerman.Publishing.Data.Initialization;
using Takerman.Publishing.Server.Middleware;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.Abstraction;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publishing.Tests
{
    public class TestFixture : TestBedFixture
    {
        private readonly string _dataAssembly;

        public TestFixture()
        {
            _dataAssembly = "Takerman.Publishing.Data";
        }

        protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
            => services.AddDbContext<DefaultContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Takerman.Publishing.Data")))
                .AddTransient<DbContext, DefaultContext>()
                .AddAutoMapper(Assembly.Load(_dataAssembly))
                .AddTransient<IProjectsService, ProjectsService>()
                .AddTransient<IPublishService, PublishService>()
                .AddTransient<IContextInitializer, ContextInitializer>()
                .AddExceptionHandler<BadRequestExceptionHandler>()
                .AddExceptionHandler<GlobalExceptionHandler>()
                .Configure<RabbitMqConfig>(configuration.GetSection(nameof(RabbitMqConfig)));

        protected override ValueTask DisposeAsyncCore() => new();

        protected override IEnumerable<TestAppSettings> GetTestAppSettings()
        {
            var result = new List<TestAppSettings>()
            {
                new(){ Filename = "test-appsettings.json", IsOptional = false }
                // new(){ Filename = "test-appsettings.Production.json", IsOptional = true }
            };

            return result;
        }
    }
}