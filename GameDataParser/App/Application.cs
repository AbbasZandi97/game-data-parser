using GameDataParser.Deserializer;
using GameDataParser.Log;
using GameDataParser.Model;
using GameDataParser.UserInteraction;
using System.Text.Json;

namespace GameDataParser.App
{
    public class Application
    {
        //private readonly Dictionary<string, VideoGame> _videoGames;
        private readonly IDeserializer _deserializer;

        private readonly VideoGameCollection _collection;

        private readonly IErrorLogger _logger;

        private readonly IUserInteraction _userInteraction;
        public Application(IDeserializer deserializer,
                           VideoGameCollection collection,
                           IErrorLogger logger,
                           IUserInteraction userInteraction)
        {
            _deserializer = deserializer;
            _collection = collection;
            _logger = logger;
            _userInteraction = userInteraction;
        }  
        
        public void StartApp()
        {

            string fileContent = "";
            try
            {
                if (_userInteraction.GetFileName(out string path))
                {
                    fileContent = File.ReadAllText(path);
                    _collection.AddUniqueGames(_deserializer.DeserializeGames(fileContent));
                    _userInteraction.PrintVideoGames(_collection.Games);
                }
            }
            catch(JsonException je)
            {
                Console.WriteLine(je.Message);
                Console.WriteLine(fileContent);
                _userInteraction.PrintErrorHappened();
            }
            catch (InvalidDataException ide)
            {
                Console.WriteLine(ide.Message);
                _userInteraction.PrintErrorHappened();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Log(ex);
                _userInteraction.PrintErrorHappened();
            }

            _userInteraction.PrintPressKeyToCloseApp();

        }


    }
}
