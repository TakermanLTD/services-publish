using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Reflection;
using Takerman.Publishing.Generation.Abstraction;

public class YouTubeUploader : IYouTubeUploader
{
    private readonly YouTubeService _youtubeService;

    public YouTubeUploader(string clientId, string clientSecret, string applicationName)
    {
        UserCredential credential = GetUserCredential(clientId, clientSecret);
        _youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = applicationName
        });
    }

    public async Task UploadVideoAsync(string videoPath, string title)
    {
        var video = new Video
        {
            Snippet = new VideoSnippet
            {
                Title = title,
                Description = "Video uploaded via YouTube Data API v3",
                Tags = new[] { "API", "upload" },
                CategoryId = "22" // "People & Blogs" category
            },
            Status = new VideoStatus { PrivacyStatus = "unlisted" }
        };

        using var fileStream = new FileStream(videoPath, FileMode.Open);

        var videosInsertRequest = _youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
        videosInsertRequest.ProgressChanged += progress => Console.WriteLine($"Uploaded {progress.BytesSent} bytes");
        videosInsertRequest.ResponseReceived += response => Console.WriteLine($"Video id '{response.Id}' was successfully uploaded.");

        await videosInsertRequest.UploadAsync();
    }

    private UserCredential GetUserCredential(string clientId, string clientSecret)
    {
        return GoogleWebAuthorizationBroker.AuthorizeAsync(
            new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            },
            new[] { YouTubeService.Scope.YoutubeUpload },
            "user",
            CancellationToken.None,
            new FileDataStore(Assembly.GetExecutingAssembly().GetName().Name)
        ).Result;
    }
}
