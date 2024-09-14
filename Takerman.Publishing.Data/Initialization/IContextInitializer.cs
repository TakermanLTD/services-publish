namespace Takerman.Publishing.Data.Initialization
{
    public interface IContextInitializer
    {
        Task InitializeAsync();
    }
}