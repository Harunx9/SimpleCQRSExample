using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ReadModel
{
    public class TodoDetails
    {
        public Guid UUID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
