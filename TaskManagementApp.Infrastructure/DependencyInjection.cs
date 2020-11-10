using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagementApp.Application.Interfaces;
using TaskManagementApp.Infrastructure.Repositories;

namespace TaskManagementApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service)
        {
            service.AddTransient<ITaskRepository, TaskRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
