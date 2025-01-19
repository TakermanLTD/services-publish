using Microsoft.SemanticKernel.ChatCompletion;
using Takerman.Publishing.Generation.Abstraction;

namespace Takerman.Publishing.Generation
{
    public class GenreAnalyzer(IChatCompletionService _chatCompletionService) : IGenreAnalyzer
    {
        public async Task<string> GetTopGenreAsync()
        {
            var prompt = "What is currently the most popular music genre? Respond with just the genre name.";
            var chatHistory = new ChatHistory();
            chatHistory.AddUserMessage(prompt);

            var response = await _chatCompletionService.GetChatMessageContentAsync(chatHistory);
            return response.Content.Trim();
        }
    }
}