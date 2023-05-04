using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string Confirmpassword { get; set; } = null!;

        public virtual ICollection<Taskassign> Taskassigns { get; set; }
    }
}
