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
    public class CreateTodoHandler : ICommandHandler<CreateTodoCommand>
    {
        public IRepository<Todo> _todoRepo;

        public CreateTodoHandler(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public void Handle(CreateTodoCommand command)
        {
            var todo = new Todo(command.TodoUUID, command.Title);
            _todoRepo.Save(todo);
        }
    }
}
