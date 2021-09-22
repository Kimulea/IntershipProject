using AutoMapper;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Domain;

namespace Bloomcoding.Bll.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupListDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<GroupForUpdate, Group>();
        }
    }
}
