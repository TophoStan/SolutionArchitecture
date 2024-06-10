using BallComSolution.Infrastructure;
using BallComSolution.Services;

namespace BallComSolution;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Register the SupplierRepository as a singleton
        services.AddSingleton<SupplierRepository>();
        // Register the EventPublisher as a singleton
        services.AddSingleton<EventPublisher>();
        // Register the SupplierService as a singleton
        services.AddSingleton<SupplierService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
