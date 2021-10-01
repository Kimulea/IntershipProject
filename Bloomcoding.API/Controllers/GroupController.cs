using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Common.Models.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bloomcoding.API.Controllers
{
    [Route("api/Group")]
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [AllowAnonymous]
        [HttpPost("getAll")]
        public IEnumerable<GroupListDto> GetPagedGroups([FromBody] FiltersOptions filtersOptions)
        {
            var pagedGroupsDto = _groupService.GetGroups(filtersOptions);

            return pagedGroupsDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<GroupDto> GetGroup(int id)
        {
            var group = await _groupService.GetGroup(id);

            return group;
        }

        [AllowAnonymous]
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup(GroupForUpdate groupForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupDto = await _groupService.CreateGroup(groupForUpdateDto);

            return CreatedAtAction(nameof(GetGroup), new { name = groupDto.Id }, groupDto);
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGroup(int id, GroupForUpdate groupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _groupService.UpdateGroup(id, groupDto);
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            await _groupService.DeleteGroup(id);
            return Ok();
        }
    }
}
