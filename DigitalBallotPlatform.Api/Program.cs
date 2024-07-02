using DigitalBallotPlatform.Shared.Logger;
using Microsoft.AspNetCore.Server.IISIntegration;
using Newtonsoft.Json.Serialization;
using ILogger = DigitalBallotPlatform.Shared.Logger.ILogger;

namespace DigitalBallotPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenLocalhost(5001);
                options.ListenLocalhost(7300, listenOpts =>
                {
                    listenOpts.UseHttps();
                });
            });

            // Add services to the container.
            builder.Services.AddSingleton<ILogger, Logger>();


            builder.Services.AddControllers()
                .AddNewtonsoftJson(settings =>
                {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }).AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
