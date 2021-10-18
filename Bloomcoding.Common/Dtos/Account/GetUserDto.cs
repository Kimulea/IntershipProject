using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloomcoding.Common.Dtos.Account
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string username { get; set; }
        public string AvatarName { get; set; }
        public DateTime BirdthDate{ get; set; }
    }
}
