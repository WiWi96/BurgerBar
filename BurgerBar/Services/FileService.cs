using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BurgerBar.Services
{
    public class FileService : IFileService
    {
        private readonly BurgerBarContext context;
        private readonly DbSet<Entities.File> dbSet;
        private readonly IHostingEnvironment host;


        public FileService(BurgerBarContext context, IHostingEnvironment host)
        {
            this.context = context;
            dbSet = context.File;
            this.host = host;
        }

        public async Task<Entities.File> AddAsync(IFormFile filesData)
        {
            var uploadFilesPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await filesData.CopyToAsync(stream);
            }
            Entities.File file = new Entities.File { Name = fileName };
            dbSet.Add(file);
            await context.SaveChangesAsync();

            return file;
        }
    }
}
