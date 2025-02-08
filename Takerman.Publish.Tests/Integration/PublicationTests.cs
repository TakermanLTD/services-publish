using AutoMapper;
using Azure.Core;
using Takerman.Publish.Data.Entities;
using Takerman.Publish.Services.Services.Abstraction;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publish.Tests.Integration
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

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyPost_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                return _postService.Publish(new Post()
                {
                    Content = "Test content",
                    DatePublished = DateTime.UtcNow,
                    Title = "Test"
                });
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Build")]
        public async Task Should_PublishPostInFacebook_When_ThereIsCorrectConfiguration()
        {
            using var http = new HttpClient();
            var postData = new Dictionary<string, string>
            {
                {"access_token", "1163145608385171|tO2_Pt_o7CZx97mDMMRyst0Ce_0" },
                {"message", "Test content" }
            };

            var httpResponse = await http.PostAsync($"https://graph.facebook.com/takerprint/feed", new FormUrlEncodedContent(postData));
            var httpContent = await httpResponse.Content.ReadAsStringAsync();
            var response = new Tuple<int, string>((int)httpResponse.StatusCode, httpContent);
            Assert.NotNull(response);
        }
    }
}