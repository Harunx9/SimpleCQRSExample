using Domain.Commands;
using Domain.Core;
using Domain.WriteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommandHandler
{
    public class CloseTodoHandler : ICommandHandler<CloseTodoCommand>
    {
        public IRepository<Todo> _todoRepo;

        public CloseTodoHandler(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public void Handle(CloseTodoCommand command)
        {
            var todo = _todoRepo.Get(command.TodoUUID, "Todos");
            todo.Close();
            _todoRepo.Save(todo);
        }
    }
}
