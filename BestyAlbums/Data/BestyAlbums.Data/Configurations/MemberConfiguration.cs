namespace BestyAlbums.Data.Configurations
{
    using BestyAlbums.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder
                .HasIndex(x => new { x.ArtistId, x.FirstName, x.LastName })
                .IsUnique();
        }
    }
}
