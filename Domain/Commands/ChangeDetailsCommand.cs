using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
    public class ChangeDetailsCommand : ICommand
    {
        public Guid TodoUUID { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public ChangeDetailsCommand(Guid UUID,string title, string description)
        {
            TodoUUID = UUID;
            Title = title;
            Description = description;
        }
    }
}
