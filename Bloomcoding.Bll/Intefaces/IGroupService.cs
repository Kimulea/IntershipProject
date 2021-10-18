using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Common.Models.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Intefaces
{
    public interface IGroupService
    {
        public Task<int> CountGroups();
        public IEnumerable<GroupListDto> GetGroups(FiltersOptions filtersOptions);
        public Task<IEnumerable<GroupListDto>> GetUserGroups(int id, FiltersOptions filtersOptions);
        public Task<int> CountUserGroups(int id);
        public Task<GroupDto> GetGroup(int id);
        public Task<GroupDto> CreateGroup(GroupForUpdate groupForUpdateDto);
        public Task UpdateGroup(int id, GroupForUpdate groupDto);
        public Task DeleteGroup(int id);
    }
}
