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
    public class ExperienceController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ExperienceController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //GET: api/experience
        [HttpGet] // Diplays Experience database info
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperience()
        {
            return await db.Experiences.ToListAsync();
        }
        //POST: api/experience
        [HttpPost] // Adds new item to the database table 
        public async Task<ActionResult<Experience>> AddExperience(Experience expAdded)
        {
            db.Experiences.Add(expAdded);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = expAdded.ExpId }, expAdded);
        }

        // PUT: api/experience
        [HttpPut]
        public async Task<ActionResult<Experience>> UpdateExperience(Experience expUpdated)
        {
            db.Entry(expUpdated).State = EntityState.Modified;

            var expToUpdate = await GetExperience();
            try
            {
                await db.SaveChangesAsync();

                return await UpdateExperience(expUpdated);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<Experience>> DeleteExperience(int id)
        {
            var experience = await db.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            db.Experiences.Remove(experience);
            await db.SaveChangesAsync();

            return experience;
        }
    }
}
