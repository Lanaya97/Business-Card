using BusinessCard.Application.Common.AssemblyReferences;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BusinessCard.Infrastructure.Services
{
    public static class ApplicationLayer
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            AddFluentValidation(services);
            AddMediatRHandlers(services);
            AddAutoMapperProfiles(services);
        }

        private static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ValidatorContainer>();
            return services;
        }

        private static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatRContainer).Assembly));
            return services;
        }

        private static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileContainer).Assembly);
            return services;
        }


    }
}
