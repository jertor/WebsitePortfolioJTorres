using System;
using System.Collections.Generic;
using System.Text;
using WebsitePortfolioJTorres.Shared.Models;
using System.Threading.Tasks;

namespace WebsitePortfolioJTorres.Shared.Interfaces
{
    public interface IResumeService
    {
        //ContactInfoServices
        Task<List<ContactInfo>> GetContactInfo();
        Task AddContact(ContactInfo addedContact);
        //Task<ContactInfo> UpdateContact(ContactInfo updatedContact); FIX THIS

        //EducationServices
        Task<List<Education>> GetEducationInfo();
        Task AddEducation(Education addedEdu);
        Task<Education> UpdateEducation(Education updatedEdu);
        Task DeleteEducation(int id);

        //ExperienceServices
        Task<List<Experience>> GetExperienceInfo();
        Task AddExperience(Experience addedExp);
    }
}
