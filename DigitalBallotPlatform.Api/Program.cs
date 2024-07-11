using DigitalBallotPlatform.Api.Controllers;
using DigitalBallotPlatform.DataAccess.Context;
using DigitalBallotPlatform.Domain.Data.Interfaces;
using DigitalBallotPlatform.Domain.Data.Repositories;
using DigitalBallotPlatform.Shared.Logger;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.Net.WebSockets;
using System.Text;
using ILogger = DigitalBallotPlatform.Shared.Logger.ILogger;

namespace DigitalBallotPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

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
            builder.Services.AddScoped<IBallotCategoryRepo, BallotCategoryRepo>();
            builder.Services.AddScoped<IBallotMaterialRepo, BallotMaterialRepo>();
            builder.Services.AddScoped<IBallotSpecRepo, BallotSpecRepo>();
            builder.Services.AddScoped<IElectionSetupRepo, ElectionSetupRepo>();
            builder.Services.AddScoped<IPartyRepo, PartyRepo>();
            builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
            builder.Services.AddScoped<ICountyRepo, CountyRepo>();
            builder.Services.AddScoped<IPlatformUserRepo, PlatformUserRepo>();
            builder.Services.AddScoped<IRoleRepo, RoleRepo>();
            builder.Services.AddScoped<IWatermarkColorsRepo, WatermarkColorsRepo>();
            builder.Services.AddScoped<IWatermarkRepo, WatermarkRepo>();

            // Add controllers to the container.
            builder.Services.AddScoped<BallotController>();
            builder.Services.AddScoped<ElectionSetupController>();
            builder.Services.AddScoped<CountyController>();
            builder.Services.AddScoped<PlatformController>();
            builder.Services.AddScoped<WatermarkController>();

            // Add SQL Server connection strings
            var electionDbConnStrSQL = configuration.GetConnectionString("SQLElectionDbConnection");
            // Add PostgreSQL connection strings
            var electionDbConnStrPG = configuration.GetConnectionString("PGElectionDbConnection");

            builder.Services.AddDbContext<ElectionDbContext>(options => 
            options.UseSqlServer(electionDbConnStrSQL)
            .EnableSensitiveDataLogging());

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

            app.UseWebSockets();

            app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await HandleWebSocket(context, webSocket);
                }
                else
                {
                    await next();
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static async Task HandleWebSocket(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var criteria = Encoding.UTF8.GetString(buffer, 0, result.Count);
                var filteredData = ApplyCriteria(criteria);

                var serverMsg = Encoding.UTF8.GetBytes(filteredData);
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        private static string ApplyCriteria(string criteria)
        {
            return $"Needs to be implemented on how we're going to pass in criteria: {criteria}";
        }
    }
}
