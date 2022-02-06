using Microsoft.AspNetCore.Identity;

namespace MvcNews.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
