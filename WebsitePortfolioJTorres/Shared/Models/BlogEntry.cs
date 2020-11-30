using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public enum BlogSubject
    {
        Technology,
        Gaming,
        Movies
    }

    public class BlogEntry
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool ExampleCheckbox { get; set; }
        public BlogSubject Subject { get; set; }
    }
}
