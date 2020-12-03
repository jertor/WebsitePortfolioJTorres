﻿using System;
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

        //private async Task<List<Project>> GetMyProjects() 
        //{
        //    var result = await Client.GetFromJsonAsync<List<Project>>("api/myprojects");
        //    return result;
        //}

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

    }
}
