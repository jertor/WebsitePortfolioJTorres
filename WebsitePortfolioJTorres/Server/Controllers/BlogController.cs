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
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public BlogController(ApplicationDbContext db)
        {
            this.db = db;
        }


        //GET: api/blog
        [HttpGet] //GetsBlogEntries
        public async Task<ActionResult<IEnumerable<BlogEntry>>> GetBlogEntries()
        {
            return await db.BlogEntries.ToListAsync();
        }

        //POST: api/blog 
        [HttpPost] //AddsNewBlogEntry
        public async Task<ActionResult<ContactInfo>> AddBlogEntry(BlogEntry addBlog)
        {
            db.BlogEntries.Add(addBlog);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = addBlog.BlogId }, addBlog);
        }


        //PUT: api/blog
        [HttpPut]
        public async Task<ActionResult<Education>> UpdateBlogEntry(BlogEntry blogUpdated)
        {
            db.Entry(blogUpdated).State = EntityState.Modified;

            var eduToUpdate = await GetBlogEntries();
            try
            {
                await db.SaveChangesAsync();

                return await UpdateBlogEntry(blogUpdated);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogEntry>> DeleteBlogEntry(int id)
        {
            var blog = await db.BlogEntries.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            db.BlogEntries.Remove(blog);
            await db.SaveChangesAsync();

            return blog;
        }
    }
}
