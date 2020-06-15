using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Placa.Repositorio;
using Placa.Dominio;
using System.Threading.Tasks;

namespace Placa_Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly IPlacaRepositorio _repo;

        public MotoristaController(IPlacaRepositorio repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllMorotistasAsync();
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
                var results = await _repo.GetMotoristaById(MotoristaId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("viagens/{MotoristaId}")]
        public async Task<IActionResult> ViagensMotorista(int MotoristaId)
        {
            try
            {
                var results = await _repo.GetViagemAsyncByMotorista(MotoristaId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("meusproblemas/{MotoristaId}")]
        public async Task<IActionResult> ProblemasMotorista(int MotoristaId)
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
        public async Task<IActionResult> Post(Motorista model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync()) 
                {
                    return Created($"/api/evento/{model.id}", model);
                }
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

            return BadRequest();
        }

        [HttpPost("problema")]
        public async Task<IActionResult> PostProblema(ProblemaSaudeMotorista model)
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

        [HttpPut("{MotoristaId}")]
        public async Task<IActionResult> Put(int MotoristaId, Motorista model)
        {
            try
            {
                var motorista = await _repo.GetMotoristaById(MotoristaId);

                if(motorista == null) return NotFound();

                _repo.Update(model);

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

        [HttpDelete("{MotoristaId}")]
        public async Task<IActionResult> Delete(int MotoristaId)
        {
            try
            {
                var motorista = await _repo.GetMotoristaById(MotoristaId);

                if(motorista == null) return NotFound();

                _repo.Delete(motorista);

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