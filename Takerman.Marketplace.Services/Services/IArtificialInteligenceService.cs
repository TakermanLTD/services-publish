using HuggingFace;

namespace Takerman.Marketplace.Services.Services
{
    public interface IArtificialInteligenceService
    {
        Task<ICollection<GenerateTextResponseValue>> AskWithText(string input);
    }
}