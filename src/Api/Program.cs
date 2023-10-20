using Api.Filters;
using Application.Common.Interfaces;
using Domain.Common;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api
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

            builder.Services.AddDbContext<MillonAndUpContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MillonAndUp")));

            const string ApplicationAssembleName = "Application";
            Assembly applicationAssemble = Assembly.Load(ApplicationAssembleName);
            builder.Services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssemblies(applicationAssemble);
            });

            builder.Services.Configure<FiltersOptions>(builder.Configuration.GetSection("DefaultFilters"));

            builder.Services.AddTransient<IMillonAndUpContext, MillonAndUpContext>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            builder.Services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());

                return new UriService(absoluteUri);
            });

            builder.Services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

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