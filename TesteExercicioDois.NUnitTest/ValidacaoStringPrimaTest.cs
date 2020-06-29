using NUnit.Framework;
using TesteExercicioDois.Application.Service;
using TesteExercicioDois.Domain.Dto;

namespace Tests
{
    [TestFixture]
    public class ValidacaoStringPrimaTest
    {
        [Test]
        public void RetornaValidacaoStringPrima()
        {
            ValidarStringPrimaDto entrada = new ValidarStringPrimaDto()
            {
                PalavraUm = "abcd",
                PalavraDois = "cdab"
            };

            var resultado = new ValidacaoStringPrimaService().ValidarStringPrima(entrada).Result;

            Assert.AreEqual(true, resultado.Objeto.EhPrima);
        }

        [Test]
        public void RetornaValidacaoStringNaoPrima()
        {
            ValidarStringPrimaDto entrada = new ValidarStringPrimaDto()
            {
                PalavraUm = "elvis",
                PalavraDois = "lives"
            };

            var resultado = new ValidacaoStringPrimaService().ValidarStringPrima(entrada).Result;

            Assert.AreEqual(false, resultado.Objeto.EhPrima);
        }

        [Test]
        public void RetornaValidacaoTamanhoStringPrima()
        {
            ValidarStringPrimaDto entrada = new ValidarStringPrimaDto()
            {
                PalavraUm = "oi",
                PalavraDois = "ola"
            };

            var resultado = new ValidacaoStringPrimaService().ValidarStringPrima(entrada).Result;

            Assert.AreEqual(false, resultado.Objeto.EhPrima);
        }
    }
}