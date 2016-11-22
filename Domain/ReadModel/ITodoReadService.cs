using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReadModel
{
    public interface ITodoReadService
    {
        TodoList GetAll();
        TodoList GetAllActive();
        TodoList GetAllInactive();
        TodoDetails GetDetails(Guid id);
    }
}
