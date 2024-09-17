﻿using System.Net;
using System.Text.Json;

namespace Takerman.Publishing.Platforms.Jamendo
{
    public class JamendoPlatform
    {
        private readonly HttpClient _client;

        public JamendoPlatform()
        {
            _client = new()
            {
                BaseAddress = new Uri("clienturl")
            };
        }

        public async Task Download(string search, int clipsCount, string location)
        {
            var apiUrl = $"/tracks/?client_id=clientid&format=json&limit=100&&namesearch={search}";

            var response = await _client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var root = JsonSerializer.Deserialize<JamendoRootObject>(responseBody, options);
            var tracks = root.results.Where(x => !string.IsNullOrEmpty(x.audiodownload)).OrderBy((item) => new Random().Next()).Take(clipsCount).ToList();

            using var webClient = new WebClient();

            for (int i = 0; i < clipsCount; i++)
            {
                var track = tracks[i];
                var trackName = "track_" + i + ".mp3";
                var songLocation = Path.Combine(location, trackName);
                webClient.DownloadFile(track.audiodownload, songLocation);
            }
        }

        public string GetGenreApiUrl(string? genre = null)
        {
            if (genre == null)
            {
                var genres = new List<string>() {
                    "pop",
                    "rock",
                    "electronic",
                    "hiphop",
                    "jazz",
                    "indie",
                    "filmscore",
                    "classical",
                    "chillout",
                    "ambient",
                    "folk",
                    "metal",
                    "latin",
                    "rnb",
                    "reggae",
                    "punk",
                    "country",
                    "house",
                    "blues"
                };
                var randomNumber = new Random();
                var randomIndex = randomNumber.Next(genres.Count);
                genre = genres[randomIndex];
            }
            var apiUrl = $"/tracks/?client_id=clientid&format=json&limit=100&tags={genre}";
            return apiUrl;
        }
    }
}