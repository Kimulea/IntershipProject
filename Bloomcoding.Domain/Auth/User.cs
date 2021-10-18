using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloomcoding.Domain.Auth
{
    public class User: IdentityUser<int>
    {
        public User()
        {
            Groups = new HashSet<Group>();
        }

        public string AvatarName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
