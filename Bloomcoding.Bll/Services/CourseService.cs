using AutoMapper;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Courses;
using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseListDto>> GetCourses(int id, FiltersOptions filtersOptions)
        {
            var courses = await _courseRepository.GetWhere(x => x.GroupId == id);
            var count = courses.Count();
            var result = courses.OrderBy(x => x.Name)
                                .Skip((filtersOptions.PageNumber - 1) * filtersOptions.PageSize)
                                .Take(filtersOptions.PageSize)
                                .ToList();
            return _mapper.Map<List<CourseListDto>>(result);
        }
    }
}
