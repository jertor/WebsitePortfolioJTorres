using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using WebsitePortfolioJTorres.Shared.Models;

namespace WebsitePortfolioJTorres.Shared.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjects();
        Task AddProject(Project addedProj);
       //UpdateProject
       //DeleteProject


        Task<string> UploadFileImage(MultipartFormDataContent content);

    }
}
