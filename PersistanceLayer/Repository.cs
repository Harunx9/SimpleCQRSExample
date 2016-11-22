using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;

namespace PersistanceLayer
{
    public class Repository<T> : IRepository<T> where T : AgregateRoot
    {
        private IDbConnection _connection;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
        }

        public T Get(Guid id, string resource)
        {
            var sql = $@"select * from {resource} where UUID = @ItemId";
            return _connection.QueryFirst<T>(sql, new { ItemId = id });
        }

        public void Save(T agregate)
        {
            if (agregate.Version > 0)
            {
                _connection.Update<T>(agregate);
            }
            else
            {
                _connection.Insert<T>(agregate);
            }
        }
    }
}
