using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Courses;
using Bloomcoding.Common.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.API.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [AllowAnonymous]
        [HttpPost("list/{id}")]
        public async Task<IActionResult> GetGroupCourses(int id, FiltersOptions filtersOptions)
        {
            var pagedGroupsDto = await _courseService.GetCourses(id, filtersOptions);

            return Ok(pagedGroupsDto);
        }
    }
}
