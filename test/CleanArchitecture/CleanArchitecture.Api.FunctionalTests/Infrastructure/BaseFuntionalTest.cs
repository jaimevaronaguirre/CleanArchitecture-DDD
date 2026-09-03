using CleanArchitecture.Api.FunctionalTests.Users;
using CleanArchitecture.Application.Users.LoginUser;
using CleanArchitecture.Application.Users.RegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitecture.Api.FunctionalTests.Infrastructure
{
    public abstract class BaseFuntionalTest :
        IClassFixture<FuntionalTestWebAppFactory>
    {
        protected readonly HttpClient HttpClient;
        
        protected BaseFuntionalTest(FuntionalTestWebAppFactory factory)
        {            
            HttpClient = factory.CreateClient();            
        }

        protected async Task<string> GetToken()
        {
            HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
                "api/v1/users/login",
                new LoginUserRequest(
                    UserData.RegisterUserRequestTest.Email,
                    UserData.RegisterUserRequestTest.Password
                )
            );

            return await response.Content.ReadAsStringAsync();
        }
    }
}
