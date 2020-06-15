using System.Threading.Tasks;
using Placa.Dominio;

namespace Placa.Repositorio
{
    public interface IPlacaRepositorio
    {
         
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //MOTORISTA
        Task<Motorista[]> GetAllMorotistasAsync();
        Task<Motorista> GetMotoristaById(int MotoristaId);

        //VIAGEM
        Task<Viagem> GetViagemAsyncById(int ViagemId);
        Task<Viagem[]> GetViagemAsyncByMotorista(int MotoristaId);

        //PROBLEMA SAUDE
        Task<ProblemaSaude[]> GetAllProblemasAsync();
        Task<ProblemaSaude[]> GetAllProblemasAsyncByMotorista(int MotoristaId);
        Task<ProblemaSaudeMotorista> GetProblemaSaudeMotoristaAsyncByMotorista(int MotoristaId, int ProblemaSaudeId);

    }
}