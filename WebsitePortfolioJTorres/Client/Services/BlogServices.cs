using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePortfolioJTorres.Shared.Models;
using WebsitePortfolioJTorres.Shared.Interfaces;
using System.Net.Http.Json;
using System.Net.Http;
using System.IO;

namespace WebsitePortfolioJTorres.Client.Services
{
    public class BlogServices:IBlogService
    {
        private readonly HttpClient httpClient;

        public BlogServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //ADD
        public async Task AddBlog(BlogEntry addedBlog)
        {
            Console.WriteLine("AddBlog called from BlogService.cs");
            await httpClient.PostAsJsonAsync("api/blog", addedBlog);
        }
        //DELETE
        public async Task DeleteBlog(int id)
        {
            await httpClient.DeleteAsync($"api/blog/{id}");
        }

        //GET
        public async Task<List<BlogEntry>> GetBlogInfo()
        {
            Console.WriteLine("GetBlogEntries called from BlogService.cs");
            var blogInfo = await this.httpClient.GetFromJsonAsync<List<BlogEntry>>("api/blog");
            return blogInfo;
        }

        //UPDATE
        public async Task<BlogEntry> UpdateBlog(BlogEntry blogUpdated)
        {
            Console.WriteLine("Update called from resumeservice");
            var blogInfo = await httpClient.PutAsJsonAsync<BlogEntry>("api/blog", blogUpdated);
            return blogUpdated;
            //return await httpClient.PutAsJsonAsync<Education>("api/experience", updatedEdu);
        }
    }
}
