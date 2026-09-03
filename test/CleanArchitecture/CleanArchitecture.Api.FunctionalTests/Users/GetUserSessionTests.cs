using CleanArchitecture.Api.FunctionalTests.Infrastructure;
using CleanArchitecture.Application.Users.GetUserSession;
using CleanArchitecture.Application.Users.LoginUser;
using CleanArchitecture.Application.Users.RegisterUser;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Xunit;

namespace CleanArchitecture.Api.FunctionalTests.Users
{
    public class GetUserSessionTests : BaseFuntionalTest
    {
        public GetUserSessionTests(FuntionalTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Get_ShouldReturnUnauthorized_WhenTokenIsMissing()
        {
            // Arrange
            // No token set
            // Act
            var response = await HttpClient.GetAsync("api/v1/users/me");
            
            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
            // 

        }

        [Fact]
        public async Task Get_ShouldReturnUser_WhenTokenExists()
        {
            // Arrange
            var token = await GetToken();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);

            // Act
            var user = await HttpClient.GetFromJsonAsync<UserResponse>("api/v1/users/me");

            // Assert
            user.Should().NotBeNull();
            // 

        }

        [Fact]
        public async Task Login_ShouldReturnOK_WhenUserExists()
        {
            // Arrange
            var request = new LoginUserRequest(
                UserData.RegisterUserRequestTest.Email,
                UserData.RegisterUserRequestTest.Password
            );

            // Act
            var response = await HttpClient.PostAsJsonAsync("api/v1/users/login", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            // 

        }

        [Fact]
        public async Task Register_ShouldReturnOK_WhenRequestsIsValid()
        {
            // Arrange
            var request = new RegisterUserRequest(
                "testx@test.com",
                "testx",
                "testx",
                "Test11233##"
            );

            // Act
            var response = await HttpClient.PostAsJsonAsync("api/v1/users/register", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            // 

        }
    }
}
