namespace Takerman.Publishing.Generation.Abstraction
{
    public interface IGenreAnalyzer
    {
        Task<string> GetTopGenreAsync();
    }
}