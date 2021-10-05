using AutoMapper;
using Bloomcoding.Common.Dtos.Account;
using Bloomcoding.Domain.Auth;

namespace Bloomcoding.Bll.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UsersDto>();
        }
    }
}
