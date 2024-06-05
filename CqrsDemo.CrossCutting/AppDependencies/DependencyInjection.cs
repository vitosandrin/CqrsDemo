using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Infrastructure.Context;
using CqrsDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConnectionString));

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnityOfWork, UnityOfWork>();

        return services;
    }
}
