using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteExercicioDois.Application;
using TesteExercicioDois.Domain.Dto;
using TesteExercicioDois.Domain.Util;

namespace TesteExercicioDois.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimasController : ControllerBase
    {
        private readonly ValidacaoStringPrimaApplication _validacaoStringPrimaApplication;

        public PrimasController()
        {
            _validacaoStringPrimaApplication = new ValidacaoStringPrimaApplication();
        }

        /// <summary>
        /// Valida se duas strings são primas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("valida-strings-primas")]
        public async Task<IActionResult> ValidarStringPrima([FromBody]ValidarStringPrimaDto entrada)
        {
            try
            {
                var retorno = await _validacaoStringPrimaApplication.ValidarStringPrima(entrada);
                return StatusCode(StatusCodes.Status200OK, retorno);
            }
            catch (Exception ex)
            {
                var retorno = new RetornoRequisicao<object>
                {
                    Objeto = null,
                    Mensagem = $"Ocorreu um erro interno no servidor: {ex.Message}",
                    Status = HttpStatusCode.NotFound
                };

                return StatusCode(StatusCodes.Status500InternalServerError, retorno);
            }
        }
    }
}
