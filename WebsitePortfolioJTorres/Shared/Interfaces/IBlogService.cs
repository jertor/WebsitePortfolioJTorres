using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebsitePortfolioJTorres.Shared.Models;

namespace WebsitePortfolioJTorres.Shared.Interfaces
{
    public interface IBlogService
    {
        //Task<List<BlogEntry>> GetBlogInfo();
        Task AddBlog(BlogEntry addedBlog);
        Task<BlogEntry> UpdateBlog(BlogEntry updatedBlog);
        Task DeleteBlog(int id);
    }
}
