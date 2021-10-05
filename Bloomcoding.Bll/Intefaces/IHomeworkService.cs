using Bloomcoding.Common.Dtos.Homeworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Intefaces
{
    public interface IHomeworkService
    {
        Task CreateHomework(CreateHomeworkDto homeworkDto);
    }
}
