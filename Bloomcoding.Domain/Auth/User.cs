using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Bloomcoding.Domain.Auth
{
    public class User: IdentityUser<int>
    {
        public User()
        {
            Groups = new HashSet<Group>();
        }

        public string AvatarName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
