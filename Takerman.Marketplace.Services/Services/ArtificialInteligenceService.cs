using HuggingFace;
using Microsoft.Extensions.Options;
using Takerman.Marketplace.Services.Configuration;

namespace Takerman.Marketplace.Services.Services
{
    public class ArtificialInteligenceService(IOptions<CommonConfig> _commonConfig) : IArtificialInteligenceService
    {
        public async Task<ICollection<GenerateTextResponseValue>> AskWithText(string input)
        {
            try
            {
                using var client = new HttpClient();
                var api = new HuggingFaceApi(_commonConfig.Value.HuggingFaceAPI, client);
                var response = await api.GenerateTextAsync(
                    RecommendedModelIds.Gpt2,
                    new GenerateTextRequest
                    {
                        Inputs = input,
                        Parameters = new GenerateTextRequestParameters
                        {
                            Max_new_tokens = 250,
                            Return_full_text = false,
                        },
                        Options = new GenerateTextRequestOptions
                        {
                            Use_cache = true,
                            Wait_for_model = false,
                        },
                    });

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}