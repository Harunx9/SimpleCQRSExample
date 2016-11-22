using Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace PersistanceLayer
{
    public class TodoReadService : ITodoReadService
    {
        private IDbConnection _connection;

        public TodoReadService(IDbConnection connection)
        {
            _connection = connection;
        }

        public TodoList GetAll()
        {
            var sql = @"select * from All_Todos";
            var result = _connection.Query<TodoListItem>(sql);
            return new TodoList { Items = result };
        }

        public TodoList GetAllActive()
        {
            var sql = @"select * from Active_Todos";
            var result = _connection.Query<TodoListItem>(sql);
            return new TodoList { Items = result };
        }

        public TodoList GetAllInactive()
        {
            var sql = @"select * from Inactive_Todos";
            var result = _connection.Query<TodoListItem>(sql);
            return new TodoList { Items = result };
        }

        public TodoDetails GetDetails(Guid id)
        {
            var sql = @"select * from Todo_Details where UUID = @ItemId";
            return _connection.QueryFirst<TodoDetails>(sql, new { ItemId = id });
        }
    }
}
