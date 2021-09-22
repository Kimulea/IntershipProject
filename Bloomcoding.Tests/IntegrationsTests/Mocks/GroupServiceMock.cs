using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Common.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Tests.IntegrationsTests.Mocks
{
    public class GroupServiceMock : IGroupService
    {
        public Task<GroupDto> CreateGroup(GroupForUpdate groupForUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto> GetGroup(int id)
        {
            var group = new GroupDto()
            {
                Id = 1,
                Name = "test1"
            };

            return Task.FromResult(group);
        }

        public IEnumerable<GroupListDto> GetGroups(FiltersOptions filtersOptions)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGroup(int id, GroupForUpdate groupDto)
        {
            throw new NotImplementedException();
        }
    }
}
