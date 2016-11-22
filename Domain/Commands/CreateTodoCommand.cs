using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class CreateTodoCommand : ICommand
    {
        public Guid TodoUUID { get; private set; }
        public string Title { get; private set; }

        public CreateTodoCommand(Guid UUID, string title)
        {
            TodoUUID = UUID;
            Title = title;
        }
    }
}
