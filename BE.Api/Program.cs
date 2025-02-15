using BE.Api.Middlewares;
using BE.Persistence.DependencyInjections;
using BE.Application.DependencyInjections;
using BE.Persistence.Extensions;
using BE.Api.Extensions;
namespace BE.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // # DI PersistenceService
            builder.Services.AddPersistenceServices(builder.Configuration);

            // # DI ApplicationService
            builder.Services.AddApplicationServices();

            builder.Services.AddScoped<ExceptionHandlingMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MigrationDataBase();

            app.UseHttpsRedirection();

            app.UseMiddlewares();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
