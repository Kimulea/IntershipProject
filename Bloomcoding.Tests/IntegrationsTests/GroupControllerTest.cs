using Bloomcoding.API;
using Bloomcoding.Common.Dtos.Groups;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bloomcoding.Tests.IntegrationsTests
{
    public class GroupControllerTest
        : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public GroupControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Returns_Ok_StatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/Group?id=1";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Get_Returns_Group()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = "/api/Group?id=1";

            // Act
            var group = await client.GetFromJsonAsync<GroupDto>(url);

            // Assert
            Assert.NotNull(group);
            Assert.Equal("test1", group.Name);
        }
    }
}
