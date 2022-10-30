using Entities.Entidades;
using Infrastructure.Mapeamentos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuracoes
{
    public class ContextoBase :
        IdentityDbContext<UsuarioAplicacao>
    {
        public ContextoBase(
            DbContextOptions<ContextoBase> options)
            : base(options)
        {
        }

        public DbSet<Igreja> Igrejas { get; set; }
        public DbSet<UsuarioAplicacao> UsuarioAplicacao { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UsuarioAplicacao>()
                .ToTable("AspNetUsers")
            .HasKey(p => p.Id);

            builder.ApplyConfiguration(new IgrejaMap());
        }
    }
}
