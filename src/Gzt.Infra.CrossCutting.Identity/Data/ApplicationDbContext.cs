using Gzt.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gzt.Infra.CrossCutting.Identity.Data
{

    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole, string>
    {
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }        
        public DbSet<Telefone> Telefones { get; set; }
        
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

            modelBuilder.Entity<Telefone>()
             .HasOne(e => e.User)
             .WithMany(c => c.Telefones);

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
            // builder.Entity<Blog>().ForSqlServerIsMemoryOptimized();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
