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
    public class EducationController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public EducationController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //GET: api/education
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducation()
        {
            return await db.Degrees.ToListAsync();
        }

        //POST api/contacts
        [HttpPost]
        public async Task<ActionResult<Education>> AddEducation(Education eduAdded)
        {
            db.Degrees.Add(eduAdded);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetEducation", new { id = eduAdded.EduId, eduAdded });
        }


        // PUT: api/education
        [HttpPut]
        public async Task<ActionResult<Education>> UpdateEducation(Education eduUpdated)
        {
            db.Entry(eduUpdated).State = EntityState.Modified;

            var eduToUpdate = await GetEducation();
            try
            {
                await db.SaveChangesAsync();

                return await UpdateEducation(eduUpdated);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
    }
}
