using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Placa.Dominio;

namespace Placa.Repositorio
{
    public class PlacaRepositorio : IPlacaRepositorio
    {
        // GERAL
        private readonly PlacaContexto _context;
        public PlacaRepositorio(PlacaContexto context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
             _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
             _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //MOTORISTA
        public async Task<Motorista[]> GetAllMorotistasAsync()
        {
            IQueryable<Motorista> query = _context.Motoristas
                .Include(psm => psm.ProblemasSaudeMotorista)
                .ThenInclude(p => p.ProblemaSaude)
                .Include(c => c.viagens);
            return await query.ToArrayAsync();
        }

        public async Task<Motorista> GetMotoristaById(int MotoristaId)
        {
            IQueryable<Motorista> query = _context.Motoristas
                .Include(psm => psm.ProblemasSaudeMotorista)
                .ThenInclude(p => p.ProblemaSaude)
                .Include(c => c.viagens)
                .Where(m => m.id == MotoristaId);

            return await query.FirstOrDefaultAsync();
        }

        //VIAGEM
        public async Task<Viagem> GetViagemAsyncById(int ViagemId)
        {
            IQueryable<Viagem> query = _context.Viagens
                .Where(v => v.id == ViagemId);

            return await query.FirstOrDefaultAsync();
        }

        //PROBLEMA SAUDE
        public async Task<ProblemaSaude[]> GetAllProblemasAsync()
        {
             IQueryable<ProblemaSaude> query = _context.ProblemasSaude;
               
            return await query.ToArrayAsync();
        }
    }
}