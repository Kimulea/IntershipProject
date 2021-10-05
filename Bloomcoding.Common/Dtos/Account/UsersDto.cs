using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomcoding.Common.Dtos.Account
{
    public class UsersDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AvatarName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
