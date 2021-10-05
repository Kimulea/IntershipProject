using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Domain
{
    public class Homework : BaseEntity
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime Deadaline { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
