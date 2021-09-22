using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Domain
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Group> Groups { get; set; }
    }
}
