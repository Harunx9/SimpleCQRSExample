using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReadModel
{
    public class TodoList
    {
        public IEnumerable<TodoListItem> Items { get; set; }
    }

    public class TodoListItem
    {
        public Guid UUID { get; set; }
        public string Title { get; set; }
    }
}
