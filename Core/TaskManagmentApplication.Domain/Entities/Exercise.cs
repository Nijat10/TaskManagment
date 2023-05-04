using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.Domain.Entities
{
    public partial class Exercise
    {
        public Exercise()
        {
            Images = new HashSet<Image>();
            Taskassigns = new HashSet<Taskassign>();
        }

        public int Taskid { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int Status { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Taskassign> Taskassigns { get; set; }
    }
}