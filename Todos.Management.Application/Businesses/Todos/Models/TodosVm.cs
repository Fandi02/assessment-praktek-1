using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Management.Application.Businesses.Todos.Models
{
    public enum Status
    {
        NotFinishedYet,
        Finished
    }
    public class TodosVm
    {
        public Guid TodoId { get; set; } = new Guid();
        public string TodoName { get; set; }
        public Status StatusTodo { get; set; }
    }
}
