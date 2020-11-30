using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
