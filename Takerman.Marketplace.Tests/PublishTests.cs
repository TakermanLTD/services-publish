using Takerman.Marketplace.Services.Services;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Takerman.Marketplace.Tests
{
    public class PublishTests : TestBed<TestFixture>
    {
        private readonly IArtificialInteligenceService? _artificialInteligenceService;

        public PublishTests(ITestOutputHelper testOutputHelper, TestFixture fixture) : base(testOutputHelper, fixture)
        {
            _artificialInteligenceService = _fixture.GetService<IArtificialInteligenceService>(_testOutputHelper);
        }

        [Fact]
        public async Task Should_OutputResult_When_AIisRequested()
        {
            var result = await _artificialInteligenceService.AskWithText("how much is 2 + 2?");

            Assert.NotNull(result);
        }
    }
}