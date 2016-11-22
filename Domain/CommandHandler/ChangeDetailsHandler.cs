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
    public class ChangeDetailsHandler : ICommandHandler<ChangeDetailsCommand>
    {
        public IRepository<Todo> _todoRepo;

        public ChangeDetailsHandler(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public void Handle(ChangeDetailsCommand command)
        {
            var todo = _todoRepo.Get(command.TodoUUID, "Todos");
            todo.ChangeTitle(command.Title);
            todo.ChangeDescription(command.Description);
            _todoRepo.Save(todo);
        }
    }
}
