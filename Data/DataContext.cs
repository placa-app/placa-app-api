using Microsoft.EntityFrameworkCore;
using Placa.API.Model;

namespace Placa.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Motorista> motoristas { get; set; }
        public DbSet<Viagem> viagens { get; set; }
        
    }
}