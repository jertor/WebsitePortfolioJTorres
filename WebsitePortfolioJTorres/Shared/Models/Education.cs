using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public class Education
    {
        public int EduId { get; set; }
        public string SchoolName { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string Certificate { get; set; }
        public string Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
