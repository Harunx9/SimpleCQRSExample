using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public abstract class AgregateRoot
    {
        [ExplicitKey]
        public Guid UUID { get; set; }
        public virtual int Version { get; set; }

        public void UpdateVersion()
        {
            Version++;
        }
    }
}
