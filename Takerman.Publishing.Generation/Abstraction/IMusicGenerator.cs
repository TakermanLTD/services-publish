namespace Takerman.Publishing.Generation.Abstraction
{
    public interface IMusicGenerator
    {
        Task<string> GenerateMusicAsync(string genre);
    }
}