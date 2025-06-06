
using DataAccess.DBContexts.ProjectSuiteDB;
using DataAccess.Repositories.ProjectSuite;
using DataAccess.Repositories.ProjectSuite.Interfaces;
using DataAccess.Services;
using DataAccess.Services.Interfaces;
using DataAccess.UnitOfWorks._Base;
using DataAccess.UnitOfWorks.ProjectSuiteDB;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //var connectionString = Environment.GetEnvironmentVariable("ProjectSuiteDB_ConnectionString");

            //var connectionString = builder.Configuration["ConnectionStrings:ProjectSuiteDB"];
            var connectionString = Environment.GetEnvironmentVariable("ProjectSuiteDB_ConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'ProjectSuiteDB' was not found in the environment variables.");
            }

            builder.Services.AddDbContext<ProjectSuiteDBContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IBaseUnitOfWork, ProjectSuiteUnitofWork>();
            builder.Services.AddScoped<IProjectSuiteUnitofWork, ProjectSuiteUnitofWork>();

            // Add services to the container.
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
