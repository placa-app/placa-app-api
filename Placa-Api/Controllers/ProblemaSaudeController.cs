using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Placa.Repositorio;
using Placa.Dominio;
using System.Threading.Tasks;

namespace Placa_Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class ProblemaSaudeController : ControllerBase
    {
        private readonly IPlacaRepositorio _repo;

        public ProblemaSaudeController(IPlacaRepositorio repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllProblemasAsync();
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("{MotoristaId}")]
        public async Task<IActionResult> Get(int MotoristaId)
        {
            try
            {
                var results = await _repo.GetAllProblemasAsyncByMotorista(MotoristaId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProblemaSaude model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()) 
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }
      

        [HttpDelete]
        public async Task<IActionResult> DeleteProblema(int MotoristaId, int ProblemaSaudeId, Motorista model)
        {
            try
            {
                var problema = await _repo.GetProblemaSaudeMotoristaAsyncByMotorista(MotoristaId, ProblemaSaudeId);

                if(problema == null) return NotFound();

                _repo.Delete(problema);

                if(await _repo.SaveChangesAsync()) 
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }
    }
}