using AutoMapper;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Courses;
using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
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
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IGroupRepository groupRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _groupRepository = groupRepository;
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

        public async Task<int> CountCourses(int id)
        {
            return await _courseRepository.CountWhere(x => x.GroupId == id);
        }

        public async Task CreateCourse(CreateCourseDto createCourseDto)
        {
            var group = await _groupRepository.FirstOrDefault(x => x.Id == createCourseDto.Id);

            var course = new Course()
            {
                Name = createCourseDto.Name,
                GroupId = createCourseDto.Id,
                Group = group
            };

            await _courseRepository.Add(course);
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _courseRepository.GetById(id);

            await _courseRepository.Remove(course);
        }
    }
}
