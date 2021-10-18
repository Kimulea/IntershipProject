using Bloomcoding.Common.Dtos.Courses;
using Bloomcoding.Common.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Intefaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListDto>> GetCourses(int id, FiltersOptions filtersOptions);
        Task<int> CountCourses(int id);
        Task CreateCourse(CreateCourseDto createCourseDto);
        Task DeleteCourse(int id);
    }
}
