using GameDataParser.Model;

namespace GameDataParser.UserInteraction
{
    public interface IUserInteraction
    {
        bool GetFileName(out string userInput);
        void PrintPressKeyToCloseApp();
        void PrintVideoGames(IEnumerable<VideoGame> games);
        void PrintErrorHappened();
    }
}
