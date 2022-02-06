namespace MvcNews.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public bool Enabled { get; set; }
        public Post Post { get; set; }
    }
}
