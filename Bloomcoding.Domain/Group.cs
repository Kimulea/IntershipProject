using Bloomcoding.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Domain
{
    public class Group : BaseEntity
    {
        public Group()
        {
            Users = new HashSet<User>();
            Courses = new HashSet<Course>();
        }

        public string Name { get; set; }
        public string Info { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
