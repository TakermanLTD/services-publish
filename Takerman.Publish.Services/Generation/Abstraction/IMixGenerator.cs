namespace Takerman.Publish.Generation.Abstraction
{
    public interface IMixGenerator
    {
        void GenerateVideo(int secondsLength);

        void MixAudio(string input1, string input2, string output);

        void GenerateDeepHouseMix(string output);

        void GenerateDeepHouseBeat(string output);
    }
}