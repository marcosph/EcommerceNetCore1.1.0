using System.IO;
using Gzt.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Gzt.Infra.CrossCutting.Identity.Services;

namespace Gzt.Infra.CrossCutting.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public ApplicationDbContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // https://blogs.msdn.microsoft.com/dotnet/2016/11/16/announcing-entity-framework-core-1-1/
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Db_Gzt;Integrated Security=True");
           // optionsBuilder.ReplaceService<IEmailSender, AuthEmailMessageSender>();
           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.Entity<Blog>().ForSqlServerIsMemoryOptimized();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
