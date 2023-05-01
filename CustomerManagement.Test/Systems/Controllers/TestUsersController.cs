namespace CustomerManagement.Test.Systems.Controllers;

using CustomerManagement.API.Controllers;
using CustomerManagement.API.Models;
using CustomerManagement.API.Services;
using CustomerManagement.Test.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        // Arrange 
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            //.ReturnsAsync(new List<User>());
            //.ReturnsAsync(new List<User>() { new()
            //{
            //    Id = 1,
            //    Name = "Jane",
            //    Address = new Address()
            //    {
            //        Street = "123 Main St",
            //        City = "Madison",
            //        ZipCode = "53704"
            //    },
            //    Email = "jane@example.com"
            //}
            //});
            .ReturnsAsync(UsersFixtures.GeTestUser());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = (OkObjectResult)await sut.Get();
        // Assert 
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        // Arrange 
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();
        // Assert 
        mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        // Arrange 
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            //.ReturnsAsync(new List<User>());
            .ReturnsAsync(new List<User>() { new() 
            { 
                Id = 1, 
                Name = "Jane", 
                Address = new Address() 
                { 
                    Street = "123 Main St", 
                    City = "Madison", 
                    ZipCode = "53704" 
                }, 
                Email = "jane@example.com"
            } 
            });
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();
        // Assert 
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult) result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        // Arrange 
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        // Act
        var result = await sut.Get();
        // Assert 
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }

    /// <summary>
    /// The InlineData attribute tells the test runner to run for as many InlineData parameter there is. In this instance 2: foo and bar 
    /// </summary>
    /// <param name="input">is either "foo" or "bar"</param>
    //[Theory] // allow for parameterized unit tests
    //[InlineData("foo")]
    //[InlineData("bar")]
    //public void Test2(string input)
    //{

    //}

    //[Theory] // allow for parameterized unit tests
    //[InlineData("foo", 1)]
    //[InlineData("bar", 1)]
    //public void Test3(string input, int num)
    //{

    //}
}