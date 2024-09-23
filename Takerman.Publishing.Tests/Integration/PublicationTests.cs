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
        private readonly IPlatformService _platformService;
        private readonly IPostService _postService;
        private readonly IPostTypeService _postTypeService;
        private readonly IPlatformSecetsService _secretsService;
        private readonly IProjectPlatformsService _projectPlatformsService;
        private readonly IProjectService _projectService;

        public PublicationsTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
        : base(testOutputHelper, fixture)
        {
            _platformLinksService = _fixture.GetService<IPlatformLinksService>(_testOutputHelper);
            _platformService = _fixture.GetService<IPlatformService>(_testOutputHelper);
            _postService = _fixture.GetService<IPostService>(_testOutputHelper);
            _postTypeService = _fixture.GetService<IPostTypeService>(_testOutputHelper);
            _secretsService = _fixture.GetService<IPlatformSecetsService>(_testOutputHelper);
            _projectPlatformsService = _fixture.GetService<IProjectPlatformsService>(_testOutputHelper);
            _projectService = _fixture.GetService<IProjectService>(_testOutputHelper);
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