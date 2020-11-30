using WebsitePortfolioJTorres.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsitePortfolioJTorres.Shared.Models;

namespace WebsitePortfolioJTorres.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Resume> ResumeTbl { get; set; }
        public DbSet<ContactInfo> Contacts { get; set; }

        //public DbSet<Education> Degrees { get; set; }
        //public DbSet<Experience> Experiences { get; set; }
        //public DbSet<BlogEntry> BlogEntries { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Database Keys
            var contactEntity = builder.Entity<ContactInfo>();
            contactEntity.HasKey(ContactInfo => ContactInfo.ContactId);

            //var eduEntity = builder.Entity<Education>();
            //eduEntity.HasKey(Education => Education.EduId);

            //var expEntity = builder.Entity<Experience>();
            //expEntity.HasKey(Experience => Experience.ExpId);

            //var skillEnitity = builder.Entity<Skill>();
            //skillEnitity.HasKey(Skill => Skill.SkillId);

            //var blogEnitity = builder.Entity<BlogEntry>();
            //blogEnitity.HasKey(BlogEntry => BlogEntry.BlogId);

        }
    }
}
