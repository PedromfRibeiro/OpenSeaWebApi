using Microsoft.OpenApi.Models;
using System.Reflection;


namespace OpenSeaWebApi.Extensions;

public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration config)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WebsiteNameApi",
                Description = "WebsiteName Application OpenSeaWebApi",
                TermsOfService = new System.Uri("https://www.EmpresaTM.com/"),
                Contact = new OpenApiContact() { Name = "EmpresaTM", Email = "EmpresaTM@EmpresaTM.pt" }
            });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
            });
        });
    }
    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("v1/swagger.json", "WebsiteNameApi");
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            c.DefaultModelsExpandDepth(-1); //remove Schema from swagger
        });
    }


}