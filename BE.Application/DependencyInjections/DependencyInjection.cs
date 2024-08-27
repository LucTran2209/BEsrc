using BE.Application.Behaviors;
using BE.Application.Services.Users.Commands.Requests;
using BE.Application.Services.Users.Commands.Validators;
using BE.Domain.Abstractions.UnitOfWork;
using BE.Infrastructure.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Reflection.Metadata;

namespace BE.Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblyContaining<InsertUserValidator>();
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
            //services.AddInfrastructureCommonServices(); 
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(InsertUserCommand).Assembly);
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            return services;
        }
    }
}
