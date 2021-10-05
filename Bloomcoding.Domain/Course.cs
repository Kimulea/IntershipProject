using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Domain
{
    public class Course : BaseEntity
    {
        public Course()
        {
            Homeworks = new HashSet<Homework>();
        }

        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
