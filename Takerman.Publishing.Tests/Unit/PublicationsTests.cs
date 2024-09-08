using Takerman.Publishing.Services;
using Takerman.Publishing.Services.DTOs;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publishing.Tests.Unit
{
    public class PublicationsTests : TestBed<TestFixture>
    {
        private readonly IProjectsService _projectsService;
        private readonly IPublishService _publishService;

        public PublicationsTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
        : base(testOutputHelper, fixture)
        {
            _projectsService = _fixture.GetService<IProjectsService>(_testOutputHelper);
            _publishService = _fixture.GetService<IPublishService>(_testOutputHelper);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyABlogpost_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishBlogpostDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAPicture_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishPictureDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyASelling_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishSellingDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAShort_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishShortDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyATweet_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishTweetDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public async Task Should_PublishSuccessfullyAVideo_When_TheCorrectDataIsPassed()
        {
            var exception = await Assert.ThrowsAnyAsync<Exception>(() =>
            {
                var actual = new PublishVideoDto();

                return _publishService.Publish(actual);
            });

            Assert.Null(exception);
        }
    }
}