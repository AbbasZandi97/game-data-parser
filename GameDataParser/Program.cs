using GameDataParser.App;
using GameDataParser.Deserializer;
using GameDataParser.Log;
using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Application(new JsonDeserializer(),
                new VideoGameCollection(),
                new FileErrorLogger(), new ConsoleUserInteraction()).StartApp();
        }
    }
}
