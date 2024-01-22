using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Models;

namespace Todos.Management.Application.Businesses.Todos.Commands
{
    public class DeleteTodoCommand : IRequest<string>
    {
        public DeleteTodoCommand() { }
        public Guid TodoId { get; set; }
    }

    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, string>
    {
        private readonly List<TodosVm> _deleteTodo;

        public DeleteTodoCommandHandler(List<TodosVm> deleteTodo)
        {
            _deleteTodo = deleteTodo;
        }

        public async Task<string> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var getData = _deleteTodo.FirstOrDefault(t => t.TodoId == request.TodoId);

            if (getData == null)
            {
                throw new Exception("Data not found");
            }

            _deleteTodo.Remove(getData);

            return "Success delete todo";
        }
    }
}
