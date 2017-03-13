using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Gzt.Infra.CrossCutting.Identity.Data;
using Gzt.Infra.CrossCutting.Identity.Models;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170313201703_nome")]
    partial class nome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP")
                        .HasMaxLength(8);

                    b.Property<string>("Complemento");

                    b.Property<int>("EnderecoTipoId");

                    b.Property<string>("Endereco_");

                    b.Property<string>("Estado");

                    b.Property<string>("IdentificaoDoEndereco");

                    b.Property<string>("Municipio");

                    b.Property<string>("NomeDestinatario");

                    b.Property<string>("Numero");

                    b.Property<string>("PontoReferencia");

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("EnderecoTipoId")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.EnderecoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("EnderecoTipo");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Numero");

                    b.Property<int>("TelefoneTipoId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TelefoneTipoId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.TelefoneTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("TelefoneTipo");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.UsuarioEndereco", b =>
                {
                    b.Property<int>("EnderecoId");

                    b.Property<string>("UserId");

                    b.HasKey("EnderecoId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UsuarioEndereco");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.PessoaFisica", b =>
                {
                    b.HasBaseType("Gzt.Infra.CrossCutting.Identity.Models.User");

                    b.Property<string>("CPF");

                    b.Property<string>("DataNascimento");

                    b.Property<int>("Genero");

                    b.Property<string>("NomeCompleto");

                    b.ToTable("PessoaFisica");

                    b.HasDiscriminator().HasValue("PessoaFisica");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.PessoaJuridica", b =>
                {
                    b.HasBaseType("Gzt.Infra.CrossCutting.Identity.Models.User");

                    b.Property<string>("CNPJ");

                    b.Property<string>("InscricaoEstadual");

                    b.Property<bool>("Isento");

                    b.Property<string>("NomeFantasia");

                    b.Property<bool>("OptantePeloSimples");

                    b.Property<string>("RazaoSocial");

                    b.Property<string>("Site");

                    b.ToTable("PessoaJuridica");

                    b.HasDiscriminator().HasValue("PessoaJuridica");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.Endereco", b =>
                {
                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.EnderecoTipo", "EnderecoTipo")
                        .WithOne("Endereco")
                        .HasForeignKey("Gzt.Infra.CrossCutting.Identity.Models.Endereco", "EnderecoTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.Telefone", b =>
                {
                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.TelefoneTipo", "TelefoneTipo")
                        .WithOne("Telefone")
                        .HasForeignKey("Gzt.Infra.CrossCutting.Identity.Models.Telefone", "TelefoneTipoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.User", "User")
                        .WithMany("Telefones")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Gzt.Infra.CrossCutting.Identity.Models.UsuarioEndereco", b =>
                {
                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.Endereco", "Endereco")
                        .WithMany("UsuarioEnderecos")
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.User", "User")
                        .WithMany("UsuarioEnderecos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gzt.Infra.CrossCutting.Identity.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
