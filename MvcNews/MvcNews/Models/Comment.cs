using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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


    public class CommentEntityTypeConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .Property(x => x.Content)
                .IsRequired();

            builder
                .Property(x => x.Author)
                .IsRequired();

        }
    }
}