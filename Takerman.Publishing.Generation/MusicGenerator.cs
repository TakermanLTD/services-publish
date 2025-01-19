using OllamaSharp;
using NAudio.Wave;
using Takerman.Publishing.Generation.Abstraction;

public class MusicGenerator : IMusicGenerator
{
    private readonly OllamaApiClient _ollamaClient;

    public MusicGenerator(string ollamaServerUrl)
    {
        _ollamaClient = new OllamaApiClient(new Uri(ollamaServerUrl));
        _ollamaClient.SelectedModel = "llama3"; // Or another appropriate model
    }

    public async Task<string> GenerateMusicAsync(string genre)
    {
        var prompt = $"Generate a {genre} song in MusicLang format. The song should be between 2.5 and 4 minutes long.";

        var response = _ollamaClient.GenerateAsync(prompt);
        var musicLangCode = response;

        // Here you would interpret the MusicLang code and generate actual audio
        // For this example, we'll generate a simple sine wave
        var outputPath = $"{genre}_song.wav";
        GenerateSineWaveFile(outputPath, 440, 180); // 3 minutes of 440Hz tone

        return outputPath;
    }

    private void GenerateSineWaveFile(string outputPath, double frequency, int durationSeconds)
    {
        var sampleRate = 44100;
        var amplitude = 0.25 * short.MaxValue;
        var samples = new short[sampleRate * durationSeconds];

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = (short)(amplitude * Math.Sin((2 * Math.PI * frequency * i) / sampleRate));
        }

        using (var writer = new WaveFileWriter(outputPath, new WaveFormat(sampleRate, 16, 1)))
        {
            writer.WriteSamples(samples, 0, samples.Length);
        }
    }
}
