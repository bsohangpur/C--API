using MoviesAppApi.Repository;
using MoviesAppApi.Repository.Interface;
using MoviesAppApi.Service;
using MoviesAppApi.Service.Interface;

namespace MoviesAppApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IActorRepository, ActorRepository>();
            services.AddSingleton<IActorService, ActorService>();
            services.AddSingleton<IProducerRepository, ProducerRepository>();
            services.AddSingleton<IProducerService, ProducerService>();
            services.AddSingleton<IMovieRepository, MovieRepository>();
            services.AddSingleton<IMovieService, MovieService>();
            services.AddSingleton<IGenreRepository, GenreRepository>();
            services.AddSingleton<IGenreService, GenreService>();
            services.AddSingleton<IReviewRepository, ReviewRepository>();
            services.AddSingleton<IReviewService, ReviewService>();

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
        }

        public void Configure(IApplicationBuilder web, IWebHostEnvironment env)
        {
            web.UseRouting();

            web.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
