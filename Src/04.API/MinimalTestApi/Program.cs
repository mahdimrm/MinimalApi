using ApplicationService;
using ApplicationService.Behaviours;
using Carter;
using Dal;
using MediatR;
using System.Reflection;

namespace MinimalTest.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddApplicationServices();
            builder.Services.AddDalServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/a spnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCarter();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapCarter();
            app.Run();
        }
    }
}
