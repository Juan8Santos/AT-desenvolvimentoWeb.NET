using AT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AT.Data
{
    public class EmpresaViagemContext : DbContext
    {
        public EmpresaViagemContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CidadeDestino> CidadeDestinos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<PacotesTuristicos> PacoteTuristico { get; set; }

        public DbSet<PaisDestino> PaisDestino { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Destino>()
                .HasKey(x => new { x.PacoteTuristicoId, x.CidadeDestinoId });

            modelBuilder.Entity<Destino>()
                .HasOne(x => x.PacoteTuristico)
                .WithMany(x => x.Destinos)
                .HasForeignKey(x => x.PacoteTuristicoId);

            modelBuilder.Entity<Destino>()
                .HasOne(x => x.CidadeDestino)
                .WithMany(x => x.Destinos)
                .HasForeignKey(x => x.CidadeDestinoId);
        }
    }
}
