using EntityFrameworkLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RogoffMediaApi.HealthChecks;
using RogoffMediaLibrary.DataAccess;
using System.Text;
using WatchDog;

namespace RogoffMediaApi.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static void AddStandardServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.AddSwaggerServices();
    }

    private static void AddSwaggerServices(this WebApplicationBuilder builder)
    {
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Description = "Jwt Authorization header info using bearer tokens",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        };

        var securityRequirement = new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                    }
                },
                new string[] { }
            }
        };

        builder.Services.AddSwaggerGen(opts =>
        {
            var title = "Rogoff Media API";
            var description = "An API handling the back-end logic for Rogoff Media.";
            // Link to terms of service for API
            var terms = new Uri("https://localhost:7060/terms");
            var license = new OpenApiLicense()
            {
                Name = "This is my full license information or a link to it."
            };
            var contact = new OpenApiContact()
            {
                Name = "Shawn Rogoff",
                Email = "shawnrogoff@gmail.com",
                Url = new Uri("https://www.ShawnRogoff.com")
            };

            opts.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = $"{title} v1",
                Description = description,
                TermsOfService = terms,
                License = license,
                Contact = contact
            });

            opts.AddSecurityDefinition("bearerAuth", securityScheme);
            opts.AddSecurityRequirement(securityRequirement);
        });
    }

    public static void AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IUserData, UserData>();
        builder.Services.AddSingleton<IPostData, PostData>();
        builder.Services.AddSingleton<ICommentData, CommentData>();
        builder.Services.AddSingleton<IModerationData, ModerationData>();
    }

    public static void AddHealthCheckServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddSqlServer(builder.Configuration.GetConnectionString("RogoffMedia"));

        builder.Services.AddHealthChecks()
            .AddCheck<RandomHealthCheck>("Site Health Check")
            .AddCheck<RandomHealthCheck>("Database Health Check");
        builder.Services.AddWatchDogServices();

        builder.Services.AddHealthChecksUI(options =>
        {
            options.AddHealthCheckEndpoint("api", "/health");
            options.SetEvaluationTimeInSeconds(60);
            options.SetMinimumSecondsBetweenFailureNotifications(60);
        }).AddInMemoryStorage();
    }

    public static void AddAuthServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization(opts =>
        {
            opts.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });


        builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
                    ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(
                        builder.Configuration.GetValue<string>("Authentication:SecretKey")))
                };
            });
    }

    public static void AddApiVersioningServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new(1, 0);
            options.ReportApiVersions = true;
        });

        builder.Services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            // For swagger it replaces the v{version:apiVersion} in api routes
            options.SubstituteApiVersionInUrl = true;
        });
    }

    public static void AddDatabaseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("RogoffMedia"));
        });
    }
}
