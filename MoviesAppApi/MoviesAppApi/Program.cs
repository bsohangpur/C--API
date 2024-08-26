namespace MoviesAppApi
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] arg) =>
            Host.CreateDefaultBuilder(arg).ConfigureWebHostDefaults(
                webHost => { webHost.UseStartup<Startup>(); });
        
    }
}