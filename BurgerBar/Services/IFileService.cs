using BurgerBar.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerBar.Services
{
    public interface IFileService
    {
        Task<File> AddAsync(IFormFile filesData);
    }
}
