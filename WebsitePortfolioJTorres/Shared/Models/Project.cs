using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePortfolioJTorres.Shared.Models
{
    public class Project
    {
        public int ProjId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgName { get; set; }
        public byte[] ImgFile { get; set; } //Used to save images?

    }
}
