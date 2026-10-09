using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

public class ConsoleUserInteraction : IUserInteraction
{

    public bool GetFileName(out string userInput)
    {

        userInput = "";

        Console.WriteLine("Enter the name of the file you want to read");
        string fileName = Console.ReadLine();

        if (fileName == "")
        {
            Console.WriteLine("File name cannot be empty.");
            return false;
        }

        if (fileName is null)
        {
            Console.WriteLine("File name cannot be null.");
            return false;
        }

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return false;
        }

        userInput = fileName;
        return true;

    }

    public void PrintPressKeyToCloseApp()
    {
        Console.WriteLine("Press any key to close the app.");
        Console.ReadKey();
    }
        
    public void PrintVideoGames(IEnumerable<VideoGame> games)
    {
        Console.WriteLine("Loaded games are:");

        foreach (var game in games)
        {
            Console.WriteLine(game.ToString());
        }
    }

    public void PrintErrorHappened() =>
        Console.WriteLine("Sorry! The application has experienced an unexpected error" +
            " and will have to be  closed.");

}
