using BusinessCard.Application.Interfaces;
using BusinessCard.Infrastructure.DatabaseContext;
using BusinessCard.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;


namespace BusinessCard.Infrastructure.Services
{
    public static class InfrastructureLayer
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {

            string conn = configuration.GetConnectionString("Default");


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBusinessCardRepository, BusinessCardRepository>();



        }


    }

}
