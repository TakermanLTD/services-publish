using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using FFMpegCore;
using FFMpegCore.Enums;
using SixLabors.ImageSharp.PixelFormats;
using Takerman.Publishing.Generation.Abstraction;

public class VideoGenerator : IVideoGenerator
{
    public async Task<string> GenerateVideoAsync(string audioPath)
    {
        var frames = GenerateFrames(audioPath);
        var videoPath = await CombineFramesWithAudioAsync(frames, audioPath);
        return videoPath;
    }

    private List<string> GenerateFrames(string audioPath)
    {
        var framePaths = new List<string>();
        for (int i = 0; i < 180; i++) // Assuming 1 frame per second for 3 minutes
        {
            using (var image = new Image<Rgba32>(1920, 1080))
            {
                image.Mutate(x => x.BackgroundColor(Color.Black));
                var framePath = $"frame_{i:000}.png";
                image.Save(framePath);
                framePaths.Add(framePath);
            }
        }
        return framePaths;
    }

    private async Task<string> CombineFramesWithAudioAsync(List<string> framePaths, string audioPath)
    {
        var outputPath = "output_video.mp4";
        await FFMpegArguments
            .FromFileInput(framePaths[0], true, options => options
                .Loop(framePaths.Count))
            .AddFileInput(audioPath)
            .OutputToFile(outputPath, false, options => options
                .WithVideoCodec(VideoCodec.LibX264)
                .WithConstantRateFactor(21)
                .WithAudioCodec(AudioCodec.Aac)
                .WithVariableBitrate(4)
                .WithFastStart())
            .ProcessAsynchronously();
        return outputPath;
    }
}
