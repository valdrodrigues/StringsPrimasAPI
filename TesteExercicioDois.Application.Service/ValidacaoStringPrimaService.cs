using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TesteExercicioDois.Domain;
using TesteExercicioDois.Domain.Dto;
using TesteExercicioDois.Domain.IApplication;
using TesteExercicioDois.Domain.Util;

namespace TesteExercicioDois.Application.Service
{
    public class ValidacaoStringPrimaService : IValidacaoStringPrimaService
    {
        /// <summary>
        /// Criar um endpoint Web API onde receberá duas strings para validar se são "primas". 
        /// Uma String é considerada prima se ambas tem o mesmo tamanho,  OK
        /// e se todos os caracteres em posições impares na primeira String estão em posições impares na segunda String, 
        /// e se todos os caracteres em posições pares na primeira String estão em posições pares na segunda String.
        ///Exemplos:
        ///"oi" e "ola" não são Strings primas.
        ///"abcd" e "cdab" são Strings primas.
        ///"abcd" e "dcba" não são Strings primas.
        ///"sacada" e "casada" são Strings primas.
        ///"elvis" e "lives" não são Strings primas.
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<RetornoRequisicao<StringPrima>> ValidarStringPrima(ValidarStringPrimaDto entrada)
        {
            bool ehPrima = false;
            var retorno = new StringPrima()
            {
                EhPrima = false,
                PalavraUm = entrada.PalavraUm,
                PalavraDois = entrada.PalavraDois
            };

            try
            {
                if (entrada.PalavraUm.Length != entrada.PalavraDois.Length)
                {
                    return new RetornoRequisicao<StringPrima>()
                    {
                        Objeto = retorno,
                        Mensagem = "Palavras de tamanhos diferentes não são strings primas!",
                        Status = HttpStatusCode.OK
                    };
                }
                else
                {
                    var palavraUmArray = entrada.PalavraUm.ToArray();
                    var palavraDoisArray = entrada.PalavraDois.ToArray();

                    // Percorre todas as letras
                    for (int i = 0; i < palavraUmArray.Length; i++)
                    {
                        for (int j = 0; j < palavraDoisArray.Length; j++)
                        {
                            // Verifica se a letraUm no indice 'i' existe no palavraDois no indice 'j'.
                            if (palavraUmArray[i] == palavraDoisArray[j])
                            {
                                //Verifica se a posicao do array eh par ou impar
                                var validaPosicaoUm = i % 2 == 0 ? 0 : 1;
                                var validaPosicaoDois = j % 2 == 0 ? 0 : 1;

                                if (validaPosicaoUm == validaPosicaoDois)
                                {
                                    ehPrima = true;
                                }
                                else
                                {
                                    return new RetornoRequisicao<StringPrima>()
                                    {
                                        Objeto = retorno,
                                        Mensagem = "Resultado validação: As strings não são primas!",
                                        Status = HttpStatusCode.OK
                                    };
                                }
                            }
                        }
                    }
                }

                retorno.EhPrima = true;
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
                Objeto = retorno,
                Mensagem = "Resultado validação: As strings são primas!",
                Status = HttpStatusCode.OK
            };
        }
    }
}
