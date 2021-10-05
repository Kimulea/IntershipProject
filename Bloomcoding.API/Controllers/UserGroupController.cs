using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Groups;
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
    public class UserGroupController : BaseController
    {
        private readonly IUserGroupService _userGroupService;

        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        [AllowAnonymous]
        [HttpPost("AddUserToGroup")]
        public async Task<IActionResult> AddUserToGroup(UserGroupDto userGroupDto)
        {
            await _userGroupService.UserGroupCreate(userGroupDto.UserId, userGroupDto.GroupId);

            return Ok("succes!!");
        }
    }
}
