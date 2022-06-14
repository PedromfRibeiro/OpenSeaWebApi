using OpenSeaWebApi.Extensions;
using OpenSeaWebApi.Middleware;

namespace OpenSeaWebApi;

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
        services.AddApplicationServices(Configuration);
        services.AddIdentityServices(Configuration);

        services.AddSwagger(Configuration);
        services.AddControllers();
        services.AddCors();
        

        //services.AddHostedService<WorkerServiceExtensions>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseSwagger();
        app.UseCustomSwagger();

        app.UseHttpsRedirection();
        
        app.UseRouting();

        app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
