namespace Takerman.Publish.Generation.Abstraction
{
    public interface IYouTubeUploader
    {
        Task UploadVideoAsync(string videoPath, string title);
    }
}