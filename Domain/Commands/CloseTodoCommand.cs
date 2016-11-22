using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class CloseTodoCommand : ICommand
    {
        public Guid TodoUUID { get; private set; }

        public CloseTodoCommand(Guid UUID)
        {
            TodoUUID = UUID;
        }
    }
}
