using Demo.RealestateApp.Application;
using Demo.RealestateApp.Identity;
using Demo.RealestateApp.Infrastructure;
using Demo.RealestateApp.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Net;



namespace Demo.RealestateApp.Api
{
    public static class StartupExtentions
    {

        public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddPersistenceService(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            //builder.Services.AddScoped<LoggingMiddleware>(provider =>
            //{
            //    var logFilePath = Path.Combine( "./logs1/loge-.txt" );
            //    return new LoggingMiddleware(logFilePath);
            //});
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                });
            }
         //   app.UseMiddleware<LoggingMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();

            return app;

        }

        private static void AddSwagger(IServiceCollection services)
        {

            services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });




            //services.AddSwaggerGen(c =>
            //{
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
            //          Enter 'Bearer' [space] and then your token in the text input below.
            //          \r\n\r\nExample: 'Bearer 12345abcdef'",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = ""
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //      {
            //        {
            //          new OpenApiSecurityScheme
            //          {
            //            Reference = new OpenApiReference
            //              {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //              },
            //              Scheme = "oauth2",
            //              Name = "Bearer",
            //              In = ParameterLocation.Header,

            //            },
            //            new List<string>()
            //          }
            //        });

            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Version = "v1",
            //        Title = "Realestate app demo API",

            //    });

            //});
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<RealestateAppDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                // var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                //  logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}

