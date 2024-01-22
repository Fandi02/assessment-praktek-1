using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Models;

namespace Todos.Management.Application.Businesses.Todos.Commands
{
    public class CreateTodoCommand : IRequest<string>
    {
        public CreateTodoCommand() { }
        public string TodoName { get; set; }
    }

    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, string>
    {
        private readonly List<TodosVm> _saveTodo;

        public CreateTodoCommandHandler(List<TodosVm> saveTodo)
        {
            _saveTodo = saveTodo;
        }

        public async Task<string> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var getData = _saveTodo.FirstOrDefault(t => t.TodoName.ToLower() ==  request.TodoName.ToLower());

            if (getData != null)
            {
                throw new Exception("Todo already exists");
            }

            var saveData = new TodosVm
            {
                TodoId = Guid.NewGuid(),
                TodoName = request.TodoName,
                StatusTodo = Status.NotFinishedYet
            };

            _saveTodo.Add(saveData);

            return "Success Save Todo";
        }
    }
}
