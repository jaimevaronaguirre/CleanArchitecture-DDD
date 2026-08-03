using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Users.LoginUser
{
    public record LoginUserRequest(string Email, string Password);
    
}
