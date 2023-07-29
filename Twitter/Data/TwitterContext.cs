using Microsoft.EntityFrameworkCore;
using Twitter.Models;
using Twitter.Models.ViewModels;

namespace Twitter.Data
{
    public class TwitterContext : DbContext
    {
        public TwitterContext(DbContextOptions<TwitterContext> options) : base(options)
        {
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    }
}
