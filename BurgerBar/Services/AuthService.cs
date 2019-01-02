using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BurgerBar.Data;
using BurgerBar.Entities;
using BurgerBar.Utils;
using Microsoft.EntityFrameworkCore;

namespace BurgerBar.Services
{
    public class AuthService : IAuthService
    {
        private readonly BurgerBarContext _context;
        private readonly DbSet<User> users;

        public AuthService(BurgerBarContext context)
        {
            _context = context;
            users = _context.User;
        }

        public async Task<User> GetUserAuthenticationAsync(string userName, string password)
        {
            return await users.FirstOrDefaultAsync(x => x.Username == userName && x.Password == Cryptography.HashPassword(password));
        }
    }
}
