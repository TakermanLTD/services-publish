using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Takerman.Publishing.Generation.Abstraction;
namespace Takerman.Publishing.Generation
{
    public class VideoSongGeneratorService : BackgroundService
    {
        private readonly IMusicGenerator _musicGenerator;
        private readonly IVideoGenerator _videoGenerator;
        private readonly IYouTubeUploader _youTubeUploader;
        private readonly IGenreAnalyzer _genreAnalyzer;

        public VideoSongGeneratorService(
            IMusicGenerator musicGenerator,
            IVideoGenerator videoGenerator,
            IYouTubeUploader youTubeUploader,
            IGenreAnalyzer genreAnalyzer)
        {
            _musicGenerator = musicGenerator;
            _videoGenerator = videoGenerator;
            _youTubeUploader = youTubeUploader;
            _genreAnalyzer = genreAnalyzer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                {
                    var topGenre = await _genreAnalyzer.GetTopGenreAsync();
                    var musicPath = await _musicGenerator.GenerateMusicAsync(topGenre);
                    var videoPath = await _videoGenerator.GenerateVideoAsync(musicPath);
                    await _youTubeUploader.UploadVideoAsync(videoPath, $"AI Generated {topGenre} Video Song");
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }

}