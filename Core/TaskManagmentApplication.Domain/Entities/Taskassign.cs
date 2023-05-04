using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.Domain.Entities
{
    public partial class Taskassign
    {
        public int Id { get; set; }
        public int Taskid { get; set; }
        public int Userid { get; set; }

        public virtual Exercise Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
