using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Options;
using Takerman.Publish.Generation.Abstraction;
using Takerman.Publish.Services.Platforms.YouTube;

public class YouTubeUploader : IYouTubeUploader
{
    private readonly YouTubeService _youtubeService;
    private readonly IOptions<YouTubeConfig> _youtubeConfig;

    public YouTubeUploader(IOptions<YouTubeConfig> youtubeConfig)
    {
        _youtubeConfig = youtubeConfig;
        _youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = _youtubeConfig.Value.ApiKey,
            ApplicationName = _youtubeConfig.Value.ApplicationName
        });
    }

    public async Task UploadVideoAsync(string videoPath, string title)
    {
        var video = new Video
        {
            Snippet = new VideoSnippet
            {
                Title = title,
                Description = "AI-generated video song",
                Tags = ["AI", "Music", "Video"],
                CategoryId = "10" 
            },
            Status = new VideoStatus
            {
                PrivacyStatus = "public"
            }
        };

        using var fileStream = new FileStream(videoPath, FileMode.Open);
        var videosInsertRequest = _youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
        videosInsertRequest.ProgressChanged += progress => Console.WriteLine($"Uploaded {progress.BytesSent} bytes");
        videosInsertRequest.ResponseReceived += response => Console.WriteLine($"Video id '{response.Id}' was successfully uploaded.");

        await videosInsertRequest.UploadAsync();
    }
}
