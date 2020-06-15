using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Placa.Repositorio;
using Placa.Dominio;
using System.Threading.Tasks;

namespace Placa_Api.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IPlacaRepositorio _repo;

        public LoginController(IPlacaRepositorio repo) 
        {
            _repo = repo;
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

    }
}