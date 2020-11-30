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
        public async Task<ActionResult<ContactInfo>> AddNewBlog(BlogEntry addBlog)
        {
            db.BlogEntries.Add(addBlog);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = addBlog.BlogId }, addBlog);
        }
    }
}
