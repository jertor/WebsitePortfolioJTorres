using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public class Experience
    {
        public int ExpId { get; set; }
        public string Employer { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobDuties { get; set; }
        public string Promotions { get; set; }
        public string Awards { get; set; }

    }
}
