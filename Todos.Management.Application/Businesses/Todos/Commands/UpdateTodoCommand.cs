using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Models;

namespace Todos.Management.Application.Businesses.Todos.Commands
{
    public class UpdateTodoCommand : IRequest<string>
    {
        public UpdateTodoCommand() { }
        public Guid Id { get; set; }
        public string TodoName { get; set; }
        public Status StatusTodo { get; set; }
    }

    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, string>
    {
        private readonly List<TodosVm> _updateTodo;

        public UpdateTodoCommandHandler(List<TodosVm> updateTodo)
        {
            _updateTodo = updateTodo;
        }

        public async Task<string> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var getData = _updateTodo.FirstOrDefault(t => t.TodoId == request.Id);

            if (getData == null)
            {
                throw new Exception("Data todo not found");
            }

            if(!Enum.IsDefined(typeof(Status), request.StatusTodo))
            {
                throw new Exception("Invalid StatusTodo value");
            }

            getData.TodoId = request.Id;
            getData.TodoName = request.TodoName;
            getData.StatusTodo = request.StatusTodo;

            return "Success update todo";
        }
    }
}
