using OpenSeaWebApi.Data;
using OpenSeaWebApi.Helpers;
using OpenSeaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace OpenSeaWebApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration config)
    {
        Services = AddInterfacesScopes(Services);
        Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        Services.AddSignalR();

        Services.AddControllers().AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            o.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            o.SerializerSettings.TypeNameHandling = TypeNameHandling.None;

            //o.SerializerSettings.DefaultValueHandling    = DefaultValueHandling.Ignore;
        });

        Services.AddLogging();
        //Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(config.GetConnectionString("SqlServer")));
        Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(config.GetConnectionString("HerokuPostgres")));
        //Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "database_name"));

        return Services;
    }

    public static IServiceCollection AddInterfacesScopes(this IServiceCollection Services)
    {
        //? Services.AddScoped<Interface Class,Main Class>();
        Services.AddScoped<IAppUserRepository, AppUserRepository>();
        Services.AddScoped<IAccountRepository, AccountRepository>();

        Services.AddScoped<ITokenService, TokenService>();
        Services.AddScoped<IOpenSeaRepository, OpenSeaRepository>();

        return Services;
    }
}