using CleanArch.Application.CommandHandlers;
using CleanArch.Application.Commands;
using CleanArch.Application.Queries;
using CleanArch.Application.QueryHandlers;
using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddTransient<IRequestHandler<CreateCommand<Person>, Person>, CreateCommandHandler<Person>>();
            services.AddTransient<IRequestHandler<GetByIdQuery<Person>, Person>, GetByIdQueryHandler<Person>>();
            

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}