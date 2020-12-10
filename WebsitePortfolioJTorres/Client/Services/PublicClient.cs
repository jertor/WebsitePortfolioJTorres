using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebsitePortfolioJTorres.Shared.Models;

namespace WebsitePortfolioJTorres.Client.Services
{
    public class PublicClient
    {
        public HttpClient Client { get; }

        public PublicClient(HttpClient httpClient) 
        {
            Client = httpClient;
        }

        //GET
        public async Task<List<ContactInfo>> GetContactInfo()
        {
            {
                var contactInfo = await this.Client.GetFromJsonAsync<List<ContactInfo>>("api/contacts");
                return contactInfo;
            }
        }

        public async Task<List<Education>> GetEducationInfo()
        {
            Console.WriteLine("GetEducationInfo called from ResumeService.cs");
            var eduInfo = await this.Client.GetFromJsonAsync<List<Education>>("api/education");
            return eduInfo;
        }

        public async Task<List<Experience>> GetExperienceInfo()
        {
            Console.WriteLine("GetExperienceInfo called from ResumeService.cs");
            var expInfo = await this.Client.GetFromJsonAsync<List<Experience>>("api/experience");
            return expInfo;
        }

        
        public async Task<List<BlogEntry>> GetBlogInfo()
        {
            Console.WriteLine("GetBlogEntries called from BlogService.cs");
            var blogInfo = await this.Client.GetFromJsonAsync<List<BlogEntry>>("api/blog");
            return blogInfo;
        }



    }
}
