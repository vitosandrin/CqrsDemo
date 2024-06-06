using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Infrastructure.Context;
using CqrsDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsDemo.Application.Members.Commands.Validations;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace CqrsDemo.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(dbConnectionString);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        var handlersAssembly = Assembly.Load("CqrsDemo.Application");

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(handlersAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(handlersAssembly);

        return services;
    }
}
