using AutoMapper;
using Takerman.Publishing.Data.Entities;
using Takerman.Publishing.Services.Services.Abstraction;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publishing.Tests.Integration
{
    public class PublicationsTests : TestBed<TestFixture>
    {
        private readonly IPlatformLinksService _platformLinksService;
        private readonly IPlatformsService _platformService;
        private readonly IPostsService _postService;
        private readonly IPostTypesService _postTypeService;
        private readonly IProjectSecretsService _secretsService;
        private readonly IProjectsService _projectService;

        public PublicationsTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
        : base(testOutputHelper, fixture)
        {
            _platformLinksService = _fixture.GetService<IPlatformLinksService>(_testOutputHelper);
            _platformService = _fixture.GetService<IPlatformsService>(_testOutputHelper);
            _postService = _fixture.GetService<IPostsService>(_testOutputHelper);
            _postTypeService = _fixture.GetService<IPostTypesService>(_testOutputHelper);
            _secretsService = _fixture.GetService<IProjectSecretsService>(_testOutputHelper);
            _projectService = _fixture.GetService<IProjectsService>(_testOutputHelper);
        }

        //[Fact]
        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyPost_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                return _postService.Publish(new Post()
                {
                    Content = "Test content",
                    DatePublished = DateTime.UtcNow,
                    IsDeleted = false,
                    Name = "Test"
                });
            });

            Assert.Null(exception);
        }
    }
}