using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.API.Controllers
{
    [Route("api/[controller]")]
    public class FileController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var dir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                var path = Path.Combine(dir, "Environment/SpecialFolder/ApplicationData/", file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return Ok(new { length = file.Length, name = file.FileName });
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("get/{name}")]
        public IActionResult GetFile(string name)
        {
            var dir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var path = Path.Combine(dir, "Environment/SpecialFolder/ApplicationData");

            var file = Directory.GetFiles(path, name).FirstOrDefault();

            return Ok(new { file = file});
        }
    }
}
