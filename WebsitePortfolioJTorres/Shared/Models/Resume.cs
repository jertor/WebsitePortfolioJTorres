using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public ContactInfo MyContactInfo { get; set; } = new ContactInfo();
        public Education MyEducation { get; set; } = new Education();
        public Experience MyExperience { get; set; } = new Experience();
    }
}
