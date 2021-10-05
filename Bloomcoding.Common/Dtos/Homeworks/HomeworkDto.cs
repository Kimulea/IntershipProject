using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Common.Dtos.Homeworks
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Condition { get; set; }
        public DateTime Deadaline { get; set; }
        public string CourseName { get; set; }
    }
}
