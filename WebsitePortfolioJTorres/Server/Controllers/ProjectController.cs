using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsitePortfolioJTorres.Server.Data;
using WebsitePortfolioJTorres.Shared.Models;


namespace WebsitePortfolioJTorres.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public ProjectController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //GET: api/project
        [HttpGet] //Displays a list of projects to the client page
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return await db.Projects.ToListAsync();
        }

        //POST: api/project
        [HttpGet] //Adds new items to the database list
        public async Task<ActionResult<Project>> AddNewProject(Project addProj)
        {
            db.Projects.Add(addProj);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetAllProjects", new { id = addProj.ProjId}, addProj);
        }

    }
}
