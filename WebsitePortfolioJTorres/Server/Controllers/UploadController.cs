using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;

namespace WebsitePortfolioJTorres.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images"); // creates the folder name
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName); // creates a relative path(makes the filename dynamic to work anywhere)
                //Checks to make sure the file isn't empty
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName); //where the file is saved to
                    var dbPath = Path.Combine(folderName, fileName); // creates a relative reference 

                    //This is similiar to streams used in C++
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(dbPath); // sends back a json rendered object(path where object exists)
                }
                else
                {
                    return BadRequest(); // Throws a 400 error 
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

    }
}
