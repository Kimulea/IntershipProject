using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Bll.Intefaces
{
    public interface IUserGroupService
    {
        public Task UserGroupCreate(int userId, int groupId);
    }
}
