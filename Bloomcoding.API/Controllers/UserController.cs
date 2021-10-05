using AutoMapper;
using Bloomcoding.Common.Dtos.Account;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal.Constants;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.API.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if(user == null)
            {
                return BadRequest(new { message = "user not found" });
            } else
            {
                return Ok(new GetUserDto()
                {
                    Id = user.Id,
                    Email = user.Email,
                    username = user.UserName,
                    AvatarName = user.AvatarName,
                    BirdthDate = user.BirthDate,
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("GroupStudents/{id}")]
        public async Task<IActionResult> GetGroupStudents(int id, FiltersOptions filtersOptions)
        {
            var students = await _userManager.GetUsersInRoleAsync("student");
            var count = students.Count();
            var result = students.OrderBy(x => x.UserName).
                                Skip((filtersOptions.PageNumber - 1) * filtersOptions.PageSize)
                                .Take(filtersOptions.PageSize)
                                .ToList();
            return Ok(_mapper.Map<List<UsersDto>>(result));
        }

        [AllowAnonymous]
        [HttpPost("GroupTeachers/{id}")]
        public async Task<IActionResult> GetGroupTeachers(int id, FiltersOptions filtersOptions)
        {
            var teachers = await _userManager.GetUsersInRoleAsync("teacher");
            var count = teachers.Count();
            var result = teachers.OrderBy(x => x.UserName).
                                Skip((filtersOptions.PageNumber - 1) * filtersOptions.PageSize)
                                .Take(filtersOptions.PageSize)
                                .ToList();
            return Ok(_mapper.Map<List<UsersDto>>(result));
        }

        [AllowAnonymous]
        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(UserForRegisterDto userForRegisterDto)
        {
            var userExists = await _userManager.FindByNameAsync(userForRegisterDto.Username);

            if (userExists != null)
                return BadRequest(new { message = "User already exists" });

            User user = new User()
            {
                Email = userForRegisterDto.Email,
                UserName = userForRegisterDto.Username
            };

            var result = await _userManager.CreateAsync(user, userForRegisterDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }

            return Ok(new { message = "Admin Created!" });
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UserForUpdateDto userU)
        {
            var user = await _userManager.FindByIdAsync(userU.Id.ToString());

            user.UserName = userU.Username;
            user.Email = userU.Email;
            user.AvatarName = userU.AvatarName;
            user.BirthDate = userU.BirthDate;

            await _userManager.UpdateAsync(user);

            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return BadRequest("user not exists");

            await _userManager.DeleteAsync(user);

            return Ok();
        }
    }
}
