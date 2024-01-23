using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Commands;
using Todos.Management.Application.Businesses.Todos.Models;
using Todos.Management.Application.Businesses.Todos.Queries;

namespace Todos.Management.UnitTest
{
    public static class ConfigurationServiceTesting
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddSingleton<List<TodosVm>>();
            services.AddTransient<IRequestHandler<GetTodoQuery, IEnumerable<TodosVm>>, GetTodoQueryHandler>();
            services.AddTransient<IRequestHandler<GetTodoByIdQuery, TodosVm>, GetTodoByIdQueryhandler>();
            services.AddTransient<IRequestHandler<CreateTodoCommand, string>, CreateTodoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTodoCommand, string>, UpdateTodoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTodoCommand, string>, DeleteTodoCommandHandler>();

            return services;
        }
    }
}
