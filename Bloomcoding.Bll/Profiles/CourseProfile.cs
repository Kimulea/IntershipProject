using AutoMapper;
using Bloomcoding.Common.Dtos.Courses;
using Bloomcoding.Domain;

namespace Bloomcoding.Bll.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseListDto>();
        }
    }
}
