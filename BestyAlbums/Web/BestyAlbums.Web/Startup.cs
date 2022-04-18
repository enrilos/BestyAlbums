namespace BestyAlbums.Web
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Services;
    using Services.Contracts;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<BestyAlbumsDbContext>(options =>
                {
                    options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<ISongService, SongService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}