using System.Text.Json;
using Takerman.Extensions;

namespace Takerman.Publishing.Platforms.FreeMusicArchive
{
    public class FreeMusicArchivePlatform
    {
        private readonly HttpClient _client;

        public FreeMusicArchivePlatform(HttpClient client)
        {
            _client = client;
        }

        public async Task<FmaSongDto> GetNewest()
        {
            var response = await _client.GetAsync($"clienturl/get/tracks.json?limit=100");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var document = JsonDocument.Parse(json);
                var track = document.RootElement.GetProperty("dataset").EnumerateArray().Randomize().FirstOrDefault();

                var song = new FmaSongDto
                {
                    Title = track.GetProperty("track_title").GetString(),
                    Artist = track.GetProperty("artist_name").GetString(),
                    Url = track.GetProperty("track_url").GetString()
                };

                var songResponse = await _client.GetAsync(song.Url, HttpCompletionOption.ResponseHeadersRead);

                if (songResponse.IsSuccessStatusCode)
                {
                    song.Data = await songResponse.Content.ReadAsStreamAsync();
                }

                return song;
            }

            return null;
        }
    }
}