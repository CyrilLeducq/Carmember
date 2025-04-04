using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using CarMember_server.Data;

namespace CarMember_server.Helpers;

public static class DependencyInjectionExtensions
{
    public static void InjectDepencies(this WebApplicationBuilder builder)
    {
        // Add services to the container.

        builder.Services.AddControllers();


        builder.AddSwagger();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevelopmentConnection")!));
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

        builder.AddRepositories();

        builder.AddServices();

        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

        builder.AddAuthentication();
    }


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    private static void AddSwagger(this WebApplicationBuilder builder)
    {

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            //c.EnableAnnotations();

            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarMemberApi", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your Bearer token in the format **Bearer {token}** to access this API."
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
                        new string[] {}
                    }
                });
        });
    }




    private static void AddRepositories(this WebApplicationBuilder builder)
    {
        //builder.Services.AddScoped<IRepository<Client, int>, ClientRepository>();
    }




    private static void AddServices(this WebApplicationBuilder builder)
    {
        //builder.Services.AddHostedService<FirstRunService>();
        //builder.Services.AddScoped<IClientService, ClientService>();
    }




    private static void AddAuthentication(this WebApplicationBuilder builder)
    {
        var appSettingsSection = builder.Configuration.GetSection("AppSettings");
        var appSettings = appSettingsSection.Get<AppSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings!.SecretKey);

        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}

