using Takerman.Publishing.Generation.Abstraction;
using Microsoft.Extensions.Options;
using Takerman.Publishing.Services.Platforms.YouTube;
using System.Diagnostics;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;

public class MixGenerator : IMixGenerator
{
    public MixGenerator(IOptions<YouTubeConfig> youtubeConfig)
    {
        _youtubeConfig = youtubeConfig;
        _ffmpegPath = @"C:\Users\takerman\AppData\Local\Microsoft\WinGet\Links\ffmpeg.exe";
        _outputDir = Path.Combine(_youtubeConfig.Value.OutptDir, DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
        if (!Directory.Exists(_outputDir))
            Directory.CreateDirectory(_outputDir);
    }

    private readonly string _ffmpegPath;
    private readonly string _outputDir;
    private readonly IOptions<YouTubeConfig> _youtubeConfig;

    public void GenerateVideo(int secondsLength)
    {
        var outputPath = Path.Combine(_outputDir, "result.mp4");
        string command = $"-f lavfi -i color=c=blue:s=1280x720 -t {secondsLength} -vf \"drawtext=fontfile=/path/to/font.ttf:fontsize=30:fontcolor=white:x=(w-tw)/2:y=(h-th)/2:text='Deep House Mix'\" {outputPath}";

        var process = new Process();
        process.StartInfo.FileName = _ffmpegPath;
        process.StartInfo.Arguments = command;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        process.WaitForExit();
    }

    public void MixAudio(string input1, string input2, string output)
    {
        var outputPath = Path.Combine(_outputDir, output);
        string command = $"-i {input1} -i {input2} -filter_complex amix=inputs=2:duration=longest {outputPath}";

        var process = new Process();
        process.StartInfo.FileName = _ffmpegPath;
        process.StartInfo.Arguments = command;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        process.WaitForExit();
    }

    public void GenerateDeepHouseMix(string output)
    {
        // Generate audio elements
        GenerateDeepHouseBeat("beat.wav");
        GenerateDeepHouseBeat("bass.wav");
        GenerateDeepHouseBeat("synth.wav");

        // Mix audio elements
        MixAudio("beat.wav", "bass.wav", "temp1.wav");
        MixAudio("temp1.wav", "synth.wav", "final_mix.wav");

        // Generate video
        GenerateVideo(300); // 5-minute video

        // Combine audio and video
        var outputPath = Path.Combine(_outputDir, output);
        string command = $"-i video.mp4 -i final_mix.wav -c:v copy -c:a aac {output}";

        var process = new Process();
        process.StartInfo.FileName = _ffmpegPath;
        process.StartInfo.Arguments = command;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        process.WaitForExit();
    }

    public void GenerateDeepHouseBeat(string output)
    {
        var sineWave = new SignalGenerator()
        {
            Gain = 0.2,
            Frequency = 440,
            Type = SignalGeneratorType.Sin
        }.Take(TimeSpan.FromSeconds(5));

        var kickDrum = new SignalGenerator()
        {
            Gain = 0.5,
            Frequency = 100,
            Type = SignalGeneratorType.Sin
        }.Take(TimeSpan.FromSeconds(5));

        var mixer = new MixingSampleProvider([sineWave, kickDrum]);

        var outputPath = Path.Combine(_outputDir, output);
        WaveFileWriter.CreateWaveFile16(outputPath, mixer.ToWaveProvider16().ToSampleProvider());
    }
}
