using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MvcNews.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;


        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }


    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasMany(p => p.Posts)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}