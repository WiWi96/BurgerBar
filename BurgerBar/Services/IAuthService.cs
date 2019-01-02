using BurgerBar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IAuthService
    {
        Task<User> GetUserAuthenticationAsync(string userName, string password);
    }
}
