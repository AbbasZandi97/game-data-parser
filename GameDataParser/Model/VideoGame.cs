namespace GameDataParser.Model
{
    public class VideoGame
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }

        public override string ToString()
        {
            return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
        }

    }
}
