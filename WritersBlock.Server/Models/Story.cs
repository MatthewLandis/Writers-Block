namespace WritersBlock.Server.Models
{
    public class Story
    {
        public required string Title { get; set; }
        public required string Text { get; set; }
        public required string Author { get; set; }
        public required int Likes { get; set; }
    }
}
