using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceControls.MoreTodosManager
{
    public partial class Todo
    {
        public Todo()
        {
            this.Id = Guid.NewGuid();
            this.LastChange = DateTime.UtcNow;
        }
    }
}
