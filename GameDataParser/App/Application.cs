using GameDataParser.UserInteraction;

namespace GameDataParser.App
{
    public class Application
    {
        public void StartApp()
        {
            if (GetFileName(out string fileName))
            {
                Console.WriteLine("name entered successfully !!");
                Console.WriteLine($"file name: {fileName}");
            }
            else
            {
                ConsoleUserInteraction.PrintPressKeyToCloseApp();
            }

        }

        private bool GetFileName(out string userInput)
        {

            userInput = "";

            ConsoleUserInteraction.PrintEnterInput();
            string fileName = ConsoleUserInteraction.GetFileName();

            if (fileName == "")
            {
                ConsoleUserInteraction.PrintEmptyInput();
                return false;
            }   
            
            if (fileName is null)
            {
                ConsoleUserInteraction.PrintNullInput();
                return false;
            }   
            
            if (!File.Exists(fileName))
            {
                ConsoleUserInteraction.PrintFileNotFound();
                return false;
            }

            userInput = fileName;
            return true;

            
        }
    }
}
