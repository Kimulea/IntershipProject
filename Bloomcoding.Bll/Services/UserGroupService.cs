using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Exceptions;
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

            if (group == null)
                throw new NullException("group is null");

            if (user == null)
                throw new NullException("user is null");

            group.Users.Add(user);
            user.Groups.Add(group);
            await _groupRepository.Update(group);
            await _userManager.UpdateAsync(user);
        }
    }
}
