using Microsoft.EntityFrameworkCore;
using Placa.Dominio;

namespace Placa.Repositorio
{
    public class PlacaContexto : DbContext
    {
        public PlacaContexto(DbContextOptions<PlacaContexto> options) : base(options){}

        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }
        public DbSet<ProblemaSaude> ProblemasSaude { get; set; }
        public DbSet<ProblemaSaudeMotorista> ProblemasMotoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProblemaSaudeMotorista>()
                .HasKey(PSM => new { PSM.ProblemaSaudeId, PSM.MotoristaId});
        }

        
    }
}