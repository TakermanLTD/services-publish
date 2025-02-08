using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Options;
using Takerman.Publish.Services.Platforms.YouTube;

namespace Takerman.Publish.Platforms.YouTube
{
    public class YouTubelatform
    {
        private readonly IOptions<YouTubeConfig> _youtubeConfig;
        public readonly HttpClient _httpClient;
        private YouTubeService _youtubeService;

        public YouTubelatform(IOptions<YouTubeConfig> youtubeConfig)
        {
            _youtubeConfig = youtubeConfig;
            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _youtubeConfig.Value.ApiKey,
                ApplicationName = _youtubeConfig.Value.ApplicationName
            });
        }

        public async Task Download(string query)
        {
            var searchListRequest = _youtubeService.Search.List("snippet");
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
            var video = new Video
            {
                Snippet = new VideoSnippet()
            };
            video.Snippet.Title = title;
            video.Snippet.Description = description;
            video.Snippet.Tags = tags.Split(',');
            video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            video.Status = new VideoStatus
            {
                PrivacyStatus = "public" // "private" or "public" or "unlisted"
            };

            using (var fileStream = new FileStream(pathToVideo, FileMode.Open))
            {
                var videosInsertRequest = _youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                await videosInsertRequest.UploadAsync();
            }
        }
    }
}