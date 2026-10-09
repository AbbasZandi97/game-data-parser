using GameDataParser.Model;

namespace GameDataParser.Deserializer
{
    public interface IDeserializer
    {
        List<VideoGame> DeserializeGames(string path);
    }
}
