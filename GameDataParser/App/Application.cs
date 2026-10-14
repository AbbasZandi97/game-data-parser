using GameDataParser.Deserializer;
using GameDataParser.FileHandler;
using GameDataParser.Log;
using GameDataParser.Model;
using GameDataParser.UserInteraction;
using System.Text.Json;

namespace GameDataParser.App;

public class Application
{
    private readonly IDeserializer _deserializer;
    private readonly VideoGameCollection _collection;
    private readonly IErrorLogger _logger;
    private readonly IUserInteraction _userInteraction;
    private readonly IFileReader _fileReader;
    public Application(IDeserializer deserializer,
                       VideoGameCollection collection,
                       IErrorLogger logger,
                       IUserInteraction userInteraction,
                       IFileReader fileReader)
    {
        _deserializer = deserializer;
        _collection = collection;
        _logger = logger;
        _userInteraction = userInteraction;
        _fileReader = fileReader;
    }  
    
    public void StartApp()
    {

        string fileContent = "";
        try
        {
            if (_userInteraction.GetFileName(out string path))
            {
                fileContent = _fileReader.Read(path);
                _collection.AddUniqueGames(_deserializer.DeserializeGames(fileContent));
                _userInteraction.PrintVideoGames(_collection.Games);
            }
        }
        catch(JsonException je)
        {
            _userInteraction.PrintErrorMessage(je);
            _userInteraction.PrintSourceFileContent(fileContent);
            _userInteraction.PrintErrorHappened();
        }
        catch (InvalidDataException ide)
        {
            _userInteraction.PrintErrorMessage(ide);
            _userInteraction.PrintErrorHappened();
        }
        catch (Exception ex)
        {
            _userInteraction.PrintErrorMessage(ex);
            _logger.Log(ex);
            _userInteraction.PrintErrorHappened();
        }

        _userInteraction.PrintPressKeyToCloseApp();

    }


}
