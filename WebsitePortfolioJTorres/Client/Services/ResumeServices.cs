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
    public class ResumeServices :IResumeService
    {
        private readonly HttpClient httpClient;
        public ResumeServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //ADD
        public async Task AddContact(ContactInfo addedContact)
        {
            Console.WriteLine("AddContact called from ResumeService.cs");
            await httpClient.PostAsJsonAsync("api/contacts", addedContact);
        }

        //GET
        public async Task<List<ContactInfo>> GetContactInfo()
        {
            {
                Console.WriteLine("GetContactInfo called from ResumeService.cs");
                var contactInfo = await this.httpClient.GetFromJsonAsync<List<ContactInfo>>("api/contacts");
                return contactInfo;
            }
        }

    }
}
