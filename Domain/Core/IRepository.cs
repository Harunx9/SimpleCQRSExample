using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IWriteRepository<T> where  T : AgregateRoot
    {
        void Save(T agregate);
    }

    public interface IReadRepository<T> where T : AgregateRoot
    {
        T Get(Guid id, string resource);
    }

    public interface IRepository<T> : IWriteRepository<T>, IReadRepository<T> where T : AgregateRoot { }
}
