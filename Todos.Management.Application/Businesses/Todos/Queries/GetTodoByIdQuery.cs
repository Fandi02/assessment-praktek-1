using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Models;

namespace Todos.Management.Application.Businesses.Todos.Queries
{
    public class GetTodoByIdQuery : IRequest<TodosVm>
    {
        public Guid TodoId { get; set; }
    }

    public class GetTodoByIdQueryhandler : IRequestHandler<GetTodoByIdQuery, TodosVm>
    {
        private readonly List<TodosVm> _todoById;

        public GetTodoByIdQueryhandler(List<TodosVm> todoById)
        {
            _todoById = todoById;
        }


        public async Task<TodosVm> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            var getData = _todoById.FirstOrDefault(t => t.TodoId == request.TodoId);

            if (getData ==  null)
            {
                throw new Exception("Data todo not found");
            }

            var response = new TodosVm
            {
                TodoId = request.TodoId,
                TodoName = getData.TodoName,
                StatusTodo = getData.StatusTodo
            };

            return response;
        }
    }
}
