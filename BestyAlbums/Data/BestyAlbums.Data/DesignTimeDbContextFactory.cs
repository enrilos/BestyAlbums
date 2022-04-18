namespace BestyAlbums.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BestyAlbumsDbContext>
    {
        public BestyAlbumsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BestyAlbumsDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new BestyAlbumsDbContext(optionsBuilder.Options);
        }
    }
}
