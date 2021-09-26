namespace BestyAlbums.Data.Configurations
{
    using BestyAlbums.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
