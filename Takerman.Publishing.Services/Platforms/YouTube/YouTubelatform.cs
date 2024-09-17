using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;

namespace Takerman.Publishing.Platforms.YouTube
{
    public class YouTubelatform
    {
        public readonly HttpClient _httpClient;

        public YouTubelatform()
        {
            _httpClient = new()
            {
                BaseAddress = new Uri("https://developers.google.com/youtube/v3")
            };
        }

        public async Task<YouTubeService> Authenticate()
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None,
                    new FileDataStore("YouTubeAPI")
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTube Upload"
            });

            return youtubeService;
        }

        public async Task Download(string query)
        {
            using var stream = new FileStream("youtube.json", FileMode.Open, FileAccess.Read);
            var secrets = (await GoogleClientSecrets.FromStreamAsync(stream)).Secrets;
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, [YouTubeService.Scope.Youtube], "user", CancellationToken.None, new FileDataStore("YouTubeAPI"));

            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "YouTube Video Search"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query;
            searchListRequest.MaxResults = 100;
            var searchListResponse = await searchListRequest.ExecuteAsync();

            foreach (var searchResult in searchListResponse.Items)
            {
                Console.WriteLine($"{searchResult.Snippet.Title} ({searchResult.Id.VideoId})");
            }

            var videoIds = searchListResponse.Items.Select(item => item.Id.VideoId).ToList();
        }

        public async Task Upload(string title, string description, string tags, string pathToVideo)
        {
            var youtubeService = await Authenticate();

            var video = new Google.Apis.YouTube.v3.Data.Video();
            video.Snippet = new Google.Apis.YouTube.v3.Data.VideoSnippet();
            video.Snippet.Title = title;
            video.Snippet.Description = description;
            video.Snippet.Tags = tags.Split(',');
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new Google.Apis.YouTube.v3.Data.VideoStatus();
            video.Status.PrivacyStatus = "public"; // "private" or "public" or "unlisted"

            using (var fileStream = new FileStream(pathToVideo, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                await videosInsertRequest.UploadAsync();
            }
        }
    }
}