using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MvcNews.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }

    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Photo)
                .IsRequired(false)
                .IsUnicode(false);

        }
    }
}