namespace BestyAlbums.Data.Configurations
{
    using BestyAlbums.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder
                .HasOne(x => x.Album)
                .WithMany(s => s.Songs)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(x => new { x.Name, x.AlbumId })
                .IsUnique();
        }
    }
}
