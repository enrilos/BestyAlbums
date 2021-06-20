namespace BestyAlbums.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class BestyAlbumsDbContext : DbContext
    {
        public BestyAlbumsDbContext()
        {
        }

        public BestyAlbumsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Single> Singles { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
