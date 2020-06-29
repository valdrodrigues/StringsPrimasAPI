using System;
using System.Net;
using System.Threading.Tasks;
using TesteExercicioDois.Application.Service;
using TesteExercicioDois.Domain;
using TesteExercicioDois.Domain.Dto;
using TesteExercicioDois.Domain.IApplication;
using TesteExercicioDois.Domain.Util;

namespace TesteExercicioDois.Application
{
    public class ValidacaoStringPrimaApplication
    {
        private readonly IValidacaoStringPrimaService _validacaoStringPrimaService;

        public ValidacaoStringPrimaApplication()
        {
            _validacaoStringPrimaService = new ValidacaoStringPrimaService();
        }

        /// <summary>
        /// Chama o service de validacao de string prima
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<RetornoRequisicao<StringPrima>> ValidarStringPrima(ValidarStringPrimaDto entrada)
        {
            var retornoService = new RetornoRequisicao<StringPrima>();

            try
            {
                retornoService = await _validacaoStringPrimaService.ValidarStringPrima(entrada);

                if (retornoService.Status != HttpStatusCode.OK)
                {
                    return new RetornoRequisicao<StringPrima>()
                    {
                        Objeto = retornoService.Objeto,
                        Mensagem = retornoService.Mensagem,
                        Status = retornoService.Status
                    };
                }

            }
            catch (Exception ex)
            {
                return new RetornoRequisicao<StringPrima>()
                {
                    Objeto = null,
                    Mensagem = "Ocorreu um erro ao retornar os dados: " + ex,
                    Status = HttpStatusCode.InternalServerError
                };
            }

            return new RetornoRequisicao<StringPrima>()
            {
                Objeto = retornoService.Objeto,
                Mensagem = retornoService.Mensagem,
                Status = retornoService.Status
            };
        }
    }
}
