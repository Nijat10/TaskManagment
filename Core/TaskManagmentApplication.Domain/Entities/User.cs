using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Taskassigns = new HashSet<Taskassign>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string? Lastname { get; set; }
        public string Role { get; set; } = null!;
        public string Email { get; set; }
        public string Password { get; set; } = null!;
        public string Confirmpassword { get; set; } = null!;

        public virtual ICollection<Taskassign> Taskassigns { get; set; }
    }
}
