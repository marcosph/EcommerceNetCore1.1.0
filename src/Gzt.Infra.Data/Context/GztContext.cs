using System.IO;
using Gzt.Domain.Models;
using Gzt.Infra.Data.Mappings;
using Gzt.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gzt.Infra.Data.Context
{
    public class GztContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CustomerMap());
                        
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // dotnet ef migrations add initial -o Context/Migrations/GztContext -c GztContext
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Db_Gzt;Integrated Security=True");
        }
    }
}
