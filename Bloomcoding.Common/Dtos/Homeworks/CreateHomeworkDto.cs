using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Common.Dtos.Homeworks
{
    public class CreateHomeworkDto
    {
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime Deadaline { get; set; }
        public int CourseId{ get; set; }
    }
}
