namespace BestyAlbums.Data.Configurations
{
    using BestyAlbums.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasMany(x => x.Members)
                .WithOne(s => s.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Albums)
                .WithOne(s => s.Artist)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
