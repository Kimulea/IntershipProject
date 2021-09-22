using AutoMapper;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Bll.Profiles;
using Bloomcoding.Bll.Services;
using Bloomcoding.Common.Dtos.Groups;
using Bloomcoding.Dal.Interfaces;
using Bloomcoding.Domain;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bloomcoding.Tests
{
    public class GroupServiceTest
    {
        private readonly IGroupService _sut;
        public GroupServiceTest()
        {
            var mockRepository = new Mock<IGenericRepository<Group>>();
            var mockMapper = new Mock<IMapper>();
            
            mockRepository.Setup(x => x.GetById(It.Is<int>(x => x == 1)))
                .ReturnsAsync(new Group()
                {
                    Id = 1,
                    Name = "test1"
                });

            mockMapper.Setup(x => x.Map<Group, GroupDto>(It.IsAny<Group>()))
                .Returns(new GroupDto());

            mockMapper.Setup(x => x.Map<GroupDto, Group>(It.IsAny<GroupDto>()))
                .Returns(new Group());

            _sut = new GroupService(mockRepository.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Get_Test_ForOne_Group()
        {
            //Arrange
            var id = 1;
            //Act
            var group = await _sut.GetGroup(id);
            //Assert
            Assert.Equal(1, group.Id);
        }
    }
}
