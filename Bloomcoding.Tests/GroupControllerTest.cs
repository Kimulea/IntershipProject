using Bloomcoding.API.Controllers;
using Bloomcoding.Bll.Intefaces;
using Bloomcoding.Common.Dtos.Groups;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Bloomcoding.Tests
{
    public class GroupControllerTest
    {
        private readonly GroupController _sut;

        public GroupControllerTest()
        {
            var mockGroupService = new Mock<IGroupService>();

            mockGroupService.Setup(x => x.GetGroup(It.Is<int>(x => x == 1)))
                .ReturnsAsync(new GroupDto()
                {
                    Id = 1,
                    Name = "test1"
                });

            mockGroupService.Setup(x => x.GetGroup(It.Is<int>(x => x == 2)))
                .ReturnsAsync(new GroupDto()
                {
                    Id = 2,
                    Name = "test2"
                });

            mockGroupService.Setup(x => x.CreateGroup(It.Is<GroupForUpdate>(x => x.Name == "test")))
                .ReturnsAsync(new GroupDto()
                {
                    Id = 1,
                    Name = "test1"
                });

            mockGroupService.Setup(x => x.UpdateGroup(It.Is<int>(x => x == 1), It.Is<GroupForUpdate>(x => x.Name == "test1")));
            //var mockLogger = new Mock<ILogger<GroupController>>();

            _sut = new GroupController(mockGroupService.Object);
        }

        [Fact]
        public async Task Post_GroupForFirstId_Returns_GroupDto()
        {
            //Arrange
            var id = 1;

            //Act
            var group = await _sut.GetGroup(id);

            //Assert
            Assert.Equal("test1", group.Name);
        }

        [Fact]
        public async Task Post_GroupCreate_Returns_Response()
        {
            //Arrange
            var groupForUpdate = new GroupForUpdate() { Name = "test" };

            //Act
            var response = await _sut.CreateGroup(groupForUpdate) as ObjectResult;

            //Assert
            Assert.Equal((int) HttpStatusCode.Created, response.StatusCode);
        }

        /*[Fact]
        public async Task Put_GroupUpdate_returnsGroup()
        {
            //Arrange
            var id = 1;
            var groupForUpdate = new GroupForUpdate() { Name = "test1" };

            //Act
            var response = await _sut.UpdateGroup(id, groupForUpdate) as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }*/

        /*[Fact]
        public async Task Delete_GroupDelete_returnResponse()
        {
            //Arrange
            var id = 1;
            var groupForUpdate = new GroupForUpdate() { Name = "test1" };

            //Act
            var response = await _sut.UpdateGroup(id, groupForUpdate) as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }*/
    }
}
