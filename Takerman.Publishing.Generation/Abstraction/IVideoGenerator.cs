namespace Takerman.Publishing.Generation.Abstraction
{
    public interface IVideoGenerator
    {
        Task<string> GenerateVideoAsync(string audioPath);
    }
}