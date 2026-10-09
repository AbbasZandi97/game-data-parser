namespace GameDataParser.Model
{
    public class VideoGameCollection
    {
        private readonly Dictionary<string, VideoGame> _games = new();

        public IReadOnlyCollection<VideoGame> Games => _games.Values;

        public void AddUniqueGames(IEnumerable<VideoGame> games)
        {
            if (games is null)
                throw new InvalidDataException("Error: The source file contains no game list.");

            foreach (var game in games)
            {
                if (game is null)
                    throw new InvalidDataException("Error: The source file contains a null game entry.");

                if (game.Title is null)
                    throw new InvalidDataException("Error: A game in the source file has no title.");

                _games.TryAdd(game.Title, game);
            }
        }
    }
}
