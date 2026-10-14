using GameDataParser.Model;

namespace GameDataParser.Deserializer;

public interface IDeserializer
{
    IEnumerable<VideoGame> DeserializeGames(string path);
}
