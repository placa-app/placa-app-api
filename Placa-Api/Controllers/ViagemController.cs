using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Placa.Repositorio;
using Placa.Dominio;
using System.Threading.Tasks;

namespace Placa_Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IPlacaRepositorio _repo;

        public ViagemController(IPlacaRepositorio repo) 
        {
            _repo = repo;
        }

        [HttpGet]
       
        [HttpGet("{ViagemId}")]
        public async Task<IActionResult> Get(int ViagemId)
        {
            try
            {
                var results = await _repo.GetViagemAsyncById(ViagemId);
                return Ok(results); // retorna resultado da bunca com status code 200
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Viagem model)
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

        [HttpPut]
        public async Task<IActionResult> Put(int ViagemId, Motorista model)
        {
            try
            {
                var viagem = await _repo.GetViagemAsyncById(ViagemId);

                if(viagem == null) return NotFound();

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

        [HttpDelete]
        public async Task<IActionResult> Delete(int ViagemId, Motorista model)
        {
            try
            {
                var viagem = await _repo.GetViagemAsyncById(ViagemId);

                if(viagem == null) return NotFound();

                _repo.Delete(viagem);

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