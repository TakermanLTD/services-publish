namespace Takerman.Publishing.Generation.Abstraction
{
    public interface IYouTubeUploader
    {
        Task UploadVideoAsync(string videoPath, string title);
    }
}