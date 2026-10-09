using GameDataParser.Model;
using System.Text.Json;

namespace GameDataParser.Deserializer
{
    public class JsonDeserializer : IDeserializer
    {
        public List<VideoGame> DeserializeGames(string json)
        {

            return JsonSerializer.Deserialize<List<VideoGame>>(json);

        }
    }
}
