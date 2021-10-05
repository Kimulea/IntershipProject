using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Dal;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly UserManager<User> _userManager;

        public UserGroupService(IGroupRepository groupRepository, UserManager<User> userManager)
        {
            _groupRepository = groupRepository;
            _userManager = userManager;
        }

        public async Task UserGroupCreate(int userId, int groupId)
        {
            var group = await _groupRepository.GetById(groupId);
            var user = await _userManager.FindByIdAsync(userId.ToString());

            group.Users.Add(user);
            await _groupRepository.Update(group);
        }
    }
}
