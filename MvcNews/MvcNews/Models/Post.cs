using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        public bool IsArticle { get; set; }
        public bool Enabled { get; set; } = true;


        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public User User { get; set; }
    }


    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .Property(x => x.Headline)
                .IsRequired();

            builder
                .Property(x => x.Content)
                .IsRequired();

            builder
                .Property(x => x.Photo)
                .IsRequired();

            builder
                .HasMany(p => p.Comments)
                .WithOne(p => p.Post)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}