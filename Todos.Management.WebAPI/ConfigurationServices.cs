using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todos.Management.Application.Businesses.Todos.Commands;
using Todos.Management.Application.Businesses.Todos.Models;
using Todos.Management.Application.Businesses.Todos.Queries;
using static System.Net.Mime.MediaTypeNames;

namespace Todos.Management.WebAPI
{
    public static class ConfigurationServices
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
