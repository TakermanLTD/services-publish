using AutoMapper;
using Takerman.Publishing.Data.DTOs;
using Takerman.Publishing.Services;
using Takerman.Publishing.Services.Abstraction;
using Takerman.Publishing.Tests.TestData;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publishing.Tests.Integration
{
    public class PublicationsTests : TestBed<TestFixture>
    {
        private readonly IProjectsService _projectsService;
        private readonly IBlogService _blogService;
        private readonly IPictureService _pictureService;
        private readonly ISellingService _sellingService;
        private readonly IShortService _shortService;
        private readonly ITweetService _tweetService;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        private readonly PublicationsTestData _testData;

        public PublicationsTests(ITestOutputHelper testOutputHelper, TestFixture fixture, IMapper mapper)
        : base(testOutputHelper, fixture)
        {
            _projectsService = _fixture.GetService<IProjectsService>(_testOutputHelper);
            _blogService = _fixture.GetService<IBlogService>(_testOutputHelper);
            _pictureService = _fixture.GetService<IPictureService>(_testOutputHelper);
            _sellingService = _fixture.GetService<ISellingService>(_testOutputHelper);
            _shortService = _fixture.GetService<IShortService>(_testOutputHelper);
            _tweetService = _fixture.GetService<ITweetService>(_testOutputHelper);
            _videoService = _fixture.GetService<IVideoService>(_testOutputHelper);
            _mapper = _fixture.GetService<IMapper>(_testOutputHelper);
            _testData = new PublicationsTestData();
        }

        //[Fact]
        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyABlogpost_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = _testData.GetBlogpost();

                return _blogService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAPicture_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = new PublicationPictureDto();

                return _pictureService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyASelling_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = new PublicationSellingDto();

                return _sellingService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAShort_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = new PublicationShortDto();

                return _shortService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyATweet_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = new PublicationTweetDto();

                return _tweetService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAVideo_When_TheCorrectDataIsPassed()
        {
            var exception = await Record.ExceptionAsync(() =>
            {
                var actual = new PublicationVideoDto();

                return _videoService.Publish(actual);
            });

            Assert.Null(exception);
        }
    }
}