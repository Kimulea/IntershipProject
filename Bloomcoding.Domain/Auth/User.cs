using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Bloomcoding.Domain.Auth
{
    public class User: IdentityUser<int>
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}
