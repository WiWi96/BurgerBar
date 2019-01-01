using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BurgerBar.Data;
using BurgerBar.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IHostingEnvironment host;
        private readonly BurgerBarContext context;
        private readonly IFileService service;
        public FileController(IHostingEnvironment host, BurgerBarContext context, IFileService service)
        {
            this.context = context;
            this.host = host;
            this.service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile filesData)
        {
            if (filesData == null) return BadRequest("Null File");
            if (filesData.Length == 0)
            {
                return BadRequest("Empty File");
            }
            if (filesData.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
            if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.FileName).ToLower())) return BadRequest("Invalid file type.");

            Entities.File file = await service.AddAsync(filesData);

            return Ok(file);
        }
    }
}