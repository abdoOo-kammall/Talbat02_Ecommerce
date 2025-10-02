
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalbatAPI.Errors;
using TalbatAPI.Extensions;
using TalbatAPI.Mapping;
using TalbatCore.RepositoryContract;
using TalbatRepository;
using TalbatRepository.Data;
namespace TalbatAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options => {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.addApplicationServices();

            var app = builder.Build();


            var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var _dbContext = services.GetRequiredService<StoreDbContext>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await StoreDbSeed.seedAsync(_dbContext);

            }
            catch (Exception ex )
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Has Occured");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
