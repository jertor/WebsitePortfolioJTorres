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
    public class ProjectServices:IProjectService
    {
        private readonly HttpClient httpClient;
        public ProjectServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddProject(Project addedProj)
        {
            Console.WriteLine("AddProject called from ProductService.cs");
            await httpClient.PostAsJsonAsync("api/MyProjects", addedProj);
        }

        //Moved to PublicClient
        public async Task<List<Project>> GetProjects()
        {
            Console.WriteLine("GetProjects called from ProductService.cs");
            var projInfo = await this.httpClient.GetFromJsonAsync<List<Project>>("api/MyProjects");
            return projInfo;
        }

        
        public async Task<string> UploadFileImage(MultipartFormDataContent content)
        {
            var postResult = await httpClient.PostAsync("api/MyProjects", content);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else 
            {
                var imgUrl = Path.Combine("api/MyProjects", postContent);
                return imgUrl;
            }
        }
    }
}
