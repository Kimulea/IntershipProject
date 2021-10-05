using AutoMapper;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Homeworks;
using Bloomcoding.Dal;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly IHomeworkRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public HomeworkService(IHomeworkRepository repository, IMapper mapper, ICourseRepository courseRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task CreateHomework(CreateHomeworkDto homeworkDto)
        {
            var course = await _courseRepository.GetById(homeworkDto.CourseId);
            
            Homework homework = new Homework()
            {
                Name = homeworkDto.Name,
                Condition = homeworkDto.Condition,
                Deadaline = homeworkDto.Deadaline,
                CourseId = course.Id
            };

            course.Homeworks.Add(homework);

            await _courseRepository.Update(course);

        }
    }
}
