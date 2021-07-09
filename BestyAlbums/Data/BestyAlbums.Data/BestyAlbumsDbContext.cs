namespace BestyAlbums.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class BestyAlbumsDbContext : DbContext
    {
        public BestyAlbumsDbContext()
        {
        }

        public BestyAlbumsDbContext(DbContextOptions<BestyAlbumsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Single> Singles { get; set; }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Artist>()
                .HasMany(x => x.Members)
                .WithOne(s => s.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Artist>()
                .HasMany(x => x.Albums)
                .WithOne(s => s.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Artist>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder
                .Entity<Album>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder
                .Entity<Artist>()
                .HasMany(x => x.Singles)
                .WithOne(s => s.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Song>()
                .HasOne(x => x.Album)
                .WithMany(s => s.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
