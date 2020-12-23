using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using empresas_dotnet.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace empresas_dotnet.Infra.Context
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }
        public DbSet<Ator> Ator { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Voto> Voto { get; set; }
        public DbSet<AtorFilme> AtorFilme { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationIdentityDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            var adminId = Guid.NewGuid().ToString();
            var adminRoleId = Guid.NewGuid().ToString();
            var usuarioRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "Admin"
            },
            new IdentityRole
            {
                Id = usuarioRoleId,
                Name = "Usuario",
                NormalizedName = "Usuario"
            });

            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                PasswordHash = hasher.HashPassword(null, "Admin.123"),
                LockoutEnabled = true,
                Active = true
            });

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
               new IdentityUserClaim<string>
               {
                   Id = 1,
                   UserId = adminId,
                   ClaimType = "Usuarios",
                   ClaimValue = "Adicionar,Editar,Excluir,Listar",
               },
               new IdentityUserClaim<string>
               {
                   Id = 2,
                   UserId = adminId,
                   ClaimType = "Filmes",
                   ClaimValue = "Adicionar,Editar,Excluir,Listar",
               });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminId
            });

            modelBuilder.Entity<Ator>().HasData(
                new Ator("Jack Nicholson"),
                new Ator("Al Pacino"),
                new Ator("Robert De Niro"),
                new Ator("Dustin Hoffman"),
                new Ator("Christian Bale"),
                new Ator("Scarlett Johansson"),
                new Ator("Nicole Kidman"));

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
