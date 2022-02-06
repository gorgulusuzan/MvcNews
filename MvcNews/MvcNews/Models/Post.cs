namespace MvcNews.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public int Hit { get; set; }
        public bool Featured { get; set; }
        public Category Category { get; set; }
        public bool IsArticle { get; set; }
        public bool Enabled { get; set; } = true;
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public User User { get; set; }
    }
}
