using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Management.Application.Businesses.Todos.Models;

namespace Todos.Management.Application.Businesses.Todos.Queries
{
    public class GetTodoQuery : IRequest<IEnumerable<TodosVm>>
    {
    }

    public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, IEnumerable<TodosVm>>
    {
        private readonly List<TodosVm> _todoList;

        public GetTodoQueryHandler(List<TodosVm> todoList)
        {
            _todoList = todoList;
        }

        public async Task<IEnumerable<TodosVm>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var response = _todoList;

            return response;
        }
    }
}
