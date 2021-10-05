using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Homeworks;
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
    public class HomeworkController : BaseController
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateHomework(CreateHomeworkDto creategroupDto)
        {
            await _homeworkService.CreateHomework(creategroupDto);

            return Ok("succes");
        }
    }
}
