namespace BestyAlbums.Services
{
    using Contracts;
    using Data;

    class AlbumService : IAlbumService
    {
        private readonly BestyAlbumsDbContext context;

        public AlbumService(BestyAlbumsDbContext context)
        {
            this.context = context;
        }
    }
}
