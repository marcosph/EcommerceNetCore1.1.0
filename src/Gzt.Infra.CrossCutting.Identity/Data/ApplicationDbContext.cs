using System.IO;
using Gzt.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Gzt.Infra.CrossCutting.Identity.Services;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gzt.Infra.CrossCutting.Identity.Data
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
       
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }

    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole, string>
    {
       // public DbSet<Endereco> Endereco { get; set; }
        //public DbSet<Book> Book { get; set; }
        //public DbSet<Category> Category { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public ApplicationDbContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // https://blogs.msdn.microsoft.com/dotnet/2016/11/16/announcing-entity-framework-core-1-1/
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Db_Gzt;Integrated Security=True");
           // optionsBuilder.ReplaceService<IEmailSender, AuthEmailMessageSender>();
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region "Identity"
            modelBuilder.Entity<User>()
              .ToTable("User");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.HasKey(uc => uc.Id);
                b.ToTable("UserClaim");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("RoleClaim");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRole");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("UserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("UserToken");
            });
            #endregion

            //----------------------------------------


            modelBuilder.Entity<UsuarioEndereco>()
                 .HasKey(x => new { x.EnderecoId, x.UserId });

            modelBuilder.Entity<UsuarioEndereco>()
                .HasOne(x => x.User)
                .WithMany(y => y.UsuarioEnderecos)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UsuarioEndereco>()
                .HasOne(x => x.Endereco)
                .WithMany(y => y.UsuarioEnderecos)
                .HasForeignKey(x => x.EnderecoId);
            //-------------------------------
            modelBuilder.Entity<BookCategory>()
                 .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
            // builder.Entity<Blog>().ForSqlServerIsMemoryOptimized();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
