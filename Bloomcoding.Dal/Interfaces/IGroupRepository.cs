using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<IEnumerable<Group>> GetUserGroups(int id);
    }
}
