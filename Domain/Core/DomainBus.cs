using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IDomainBus
    {
        void RegisterHandler<T>(Type commandType, ICommandHandler<T> handler);
        void Send<T>(T command);
    }

    public class DomainBus : IDomainBus
    {
        Dictionary<Type, object> _handlers = new Dictionary<Type, object>();
        public void RegisterHandler<T>(Type commandType, ICommandHandler<T> handler)
        {
            if (_handlers.Any(x => x.Key == commandType) == false)
            {
                _handlers.Add(commandType, handler);
            }
        }

        public void Send<T>(T command)
        {
            var handler = (ICommandHandler<T>) _handlers[command.GetType()];

            handler?.Handle(command);
        }
    }
}
