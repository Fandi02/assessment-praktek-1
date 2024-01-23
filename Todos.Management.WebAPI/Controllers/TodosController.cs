using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Todos.Management.Application.Businesses.Todos.Commands;
using Todos.Management.Application.Businesses.Todos.Models;
using Todos.Management.Application.Businesses.Todos.Queries;

namespace Todos.Management.WebAPI.Controllers
{
    public class TodosController : BaseController
    {
        public TodosController() 
        {
        }

        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            return Wrapper(val: await Mediator.Send(new GetTodoQuery()));
        }

        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [HttpGet(template: "{TodoId}")]
        public async Task<ActionResult> GetDataById(Guid TodoId)
        {
            return Wrapper(val: await Mediator.Send(new GetTodoByIdQuery() { TodoId = TodoId }));
        }

        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult> CreateData([FromBody]CreateTodoCommand request)
        {
            return Wrapper(val: await Mediator.Send(request));
        }

        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [HttpPut]
        public async Task<ActionResult> UpdateData([FromBody] UpdateTodoCommand request)
        {
            return Wrapper(val: await Mediator.Send(request));
        }

        [ProducesResponseType(type: typeof(string), statusCode: StatusCodes.Status200OK)]
        [HttpDelete]
        public async Task<ActionResult> DeleteData([Required] Guid TodoId)
        {
            return Wrapper(val: await Mediator.Send(new DeleteTodoCommand() { TodoId = TodoId }));
        }
    }
}
