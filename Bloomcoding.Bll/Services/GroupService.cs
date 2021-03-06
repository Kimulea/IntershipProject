using AutoMapper;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Common.Models.Pagination;
using Bloomcoding.Dal;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Dal.Repositories;
using Bloomcoding.Domain;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CountGroups()
        {
            var groups = await _repository.GetAll();

            return groups.Count();
        }

        public IEnumerable<GroupListDto> GetGroups(FiltersOptions filtersOptions)
        {
            var groupList = _repository.GetPagedList(filtersOptions);
            return _mapper.Map<List<GroupListDto>>(groupList);
        }

        public async Task<IEnumerable<GroupListDto>> GetUserGroups(int id, FiltersOptions filtersOptions)
        {
            var groupList = await _repository.GetUserGroups(id);

            var filteredGroups = groupList.OrderBy(x => x.Name)
                                .Skip((filtersOptions.PageNumber) * filtersOptions.PageSize)
                                .Take(filtersOptions.PageSize)
                                .ToList();

            return _mapper.Map<List<GroupListDto>>(filteredGroups);
        }

        public async Task<int> CountUserGroups(int id)
        {
            var groups =  await _repository.GetUserGroups(id);
            return groups.Count();
        }

        public async Task<GroupDto> GetGroup(int id)
        {
            var group = await _repository.GetById(id);

            return _mapper.Map<GroupDto>(group);
        }

        public async Task<GroupDto> CreateGroup(GroupForUpdate groupForUpdateDto)
        {
            var group = _mapper.Map<Group>(groupForUpdateDto);
            await _repository.Add(group);

            var groupDto = _mapper.Map<GroupDto>(group);

            return groupDto;
        }

        public async Task UpdateGroup(int id, GroupForUpdate groupDto)
        {
            var group = await _repository.GetById(id);
            _mapper.Map(groupDto, group);
            await _repository.Update(group);
        }

        public async Task DeleteGroup(int id)
        {
            var group = await _repository.GetById(id);
            await _repository.Remove(group);
        }
    }
}
