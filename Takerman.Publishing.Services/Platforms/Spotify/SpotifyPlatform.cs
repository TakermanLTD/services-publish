using SpotifyAPI.Web;

namespace Takerman.Publishing.Platforms.Spotify
{
    public class SpotifyPlatform
    {
        private readonly SpotifyClient _spotify;

        public SpotifyPlatform()
        {
            _spotify = new SpotifyClient("clientid");
        }

        public async Task<SearchResponse> GetByGenre(string genre)
        {
            var searchRequest = new SearchRequest(SearchRequest.Types.Track, $"genre:\"{genre.ToLower()}\"");
            var searchResult = await _spotify.Search.Item(searchRequest);
            return searchResult;
        }
    }
}