using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Todos.Management.Application.Common.Extensions;
using Todos.Management.Application.Common.Models;

namespace Todos.Management.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected JsonResult Wrapper(object val, WrapperType wrapperType = WrapperType.OK)
        {
            var result = new Result
            {
                Path = Request.Path.HasValue ? Request.Path.Value : null
            };

            if (val.IsNotA<Unit>())
            {
                result.Payload = val;
            }

            if (wrapperType == WrapperType.Created)
            {
                result.StatusCode = (int)HttpStatusCode.Created;
            }

            return Json(result);
        }
    }

    public enum WrapperType
    {
        OK,

        Created
    }
}
