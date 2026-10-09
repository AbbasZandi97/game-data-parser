namespace GameDataParser.Log
{
    public class FileErrorLogger : IErrorLogger
    {
        private readonly string _path;
        public FileErrorLogger(string path = "log.txt") => _path = path;

        public void Log(Exception ex)
        {
            File.AppendAllText(_path, ex + Environment.NewLine);
        }
    }
}
