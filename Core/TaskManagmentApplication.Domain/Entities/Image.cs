using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.Domain.Entities
{
    public partial class Image
    {
        public int Imageid { get; set; }
        public string Imageurl { get; set; } = null!;
        public int Taskid { get; set; }

        public virtual Exercise Task { get; set; } = null!;
    }
}
