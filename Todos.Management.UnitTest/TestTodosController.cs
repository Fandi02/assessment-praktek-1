using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Todos.Management.Application.Businesses.Todos.Commands;
using Todos.Management.Application.Businesses.Todos.Models;
using Todos.Management.Application.Businesses.Todos.Queries;
using Todos.Management.Application.Common.Models;
using Todos.Management.WebAPI;
using Todos.Management.WebAPI.Controllers;

namespace Todos.Management.UnitTest
{
    [TestClass]
    public class TestTodosController
    {
        public IServiceProvider BuildServiceProvider()
        {

            var services = new ServiceCollection();

            services.AddHttpContextAccessor();

            services.Configure<ApiBehaviorOptions>(options =>
                    options.SuppressModelStateInvalidFilter = true);

            services.AddSingleton<List<TodosVm>>();
            services.AddTransient<IRequestHandler<GetTodoQuery, IEnumerable<TodosVm>>, GetTodoQueryHandler>();
            services.AddTransient<IRequestHandler<GetTodoByIdQuery, TodosVm>, GetTodoByIdQueryhandler>();
            services.AddTransient<IRequestHandler<CreateTodoCommand, string>, CreateTodoCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateTodoCommand, string>, UpdateTodoCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteTodoCommand, string>, DeleteTodoCommandHandler>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task A_SaveData_Test()
        {
            var serviceProvider = BuildServiceProvider();

            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var controllerContext = new ControllerContext { HttpContext = httpContext };

            var controller = new TodosController()
            {
                ControllerContext = controllerContext
            };

            var submitData = new CreateTodoCommand
            {
                TodoName = "Learning Testing Unit"
            };

            var result = await controller.CreateData(submitData);

            Assert.IsInstanceOfType(result, typeof(JsonResult));

            var jsonResult = result as JsonResult;

            Assert.IsInstanceOfType(jsonResult.Value, typeof(Result));

            var resultObject = jsonResult.Value as Result;

            Assert.IsNotNull(resultObject);

            if (resultObject.IsSuccess)
            {
                Assert.IsNotNull(resultObject.Payload);
                Assert.AreEqual("Success Save Todo", resultObject.Payload);
            } else
            {
                Assert.Fail("Unexpected result type");
            }
        }

        [TestMethod]
        public async Task B_GetData_Test()
        {
            var testTodos = GetDataTestTodos();

            var serviceProvider = BuildServiceProvider();

            var httpContext = new DefaultHttpContext { RequestServices = serviceProvider };
            var controllerContext = new ControllerContext { HttpContext = httpContext };

            var controller = new TodosController()
            {
                ControllerContext = controllerContext
            };

            var result = await controller.GetData();

            Assert.IsInstanceOfType(result, typeof(JsonResult));

            var jsonResult = result as JsonResult;

            Assert.IsInstanceOfType(jsonResult.Value, typeof(Result));

            var resultObject = jsonResult.Value as Result;

            Assert.IsNotNull(resultObject?.Payload);
            Assert.IsInstanceOfType(resultObject.Payload, typeof(List<TodosVm>));

            var resultList = resultObject.Payload as List<TodosVm>;

            Assert.AreEqual(testTodos.Count, resultList.Count);
        }

        private List<TodosVm> GetDataTestTodos()
        {
            var testTodos = new List<TodosVm>();
            testTodos.Add(new TodosVm() { TodoId = Guid.NewGuid(), TodoName = "Reading Documentation ASP.NET", StatusTodo = Status.NotFinishedYet });
            testTodos.Add(new TodosVm() { TodoId = Guid.NewGuid(), TodoName = "Reading Motivation Book", StatusTodo = Status.Finished });
            testTodos.Add(new TodosVm() { TodoId = Guid.NewGuid(), TodoName = "ASP.NET coding practice", StatusTodo = Status.NotFinishedYet });
            testTodos.Add(new TodosVm() { TodoId = Guid.NewGuid(), TodoName = "Meditation", StatusTodo = Status.NotFinishedYet });
            testTodos.Add(new TodosVm() { TodoId = Guid.NewGuid(), TodoName = "Make Coffee", StatusTodo = Status.NotFinishedYet });

            return testTodos;
        }
    }
}