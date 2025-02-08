using Takerman.Publish.Generation.Abstraction;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Publish.Tests.Integration
{
    public class GenerationTests : TestBed<TestFixture>
    {
        private readonly IMixGenerator? _videoGenerator;
        private readonly IYouTubeUploader? _youtubeGenerator;

        public GenerationTests(ITestOutputHelper testOutputHelper, TestFixture fixture)
        : base(testOutputHelper, fixture)
        {
            _videoGenerator = _fixture.GetService<IMixGenerator>(_testOutputHelper);
            _youtubeGenerator = _fixture.GetService<IYouTubeUploader>(_testOutputHelper);
        }

        [Fact(Skip = "Disable until the providers are ready")]
        public void Should_GenerateVideoSong_When_GenreIsSet()
        {
            var exception = Record.Exception(() =>
            {
                _videoGenerator.GenerateDeepHouseMix("result.mpeg");
            });

            Assert.Null(exception);
        }
    }
}