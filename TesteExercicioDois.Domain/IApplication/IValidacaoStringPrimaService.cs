using System.Threading.Tasks;
using TesteExercicioDois.Domain.Dto;
using TesteExercicioDois.Domain.Util;

namespace TesteExercicioDois.Domain.IApplication
{
    public interface IValidacaoStringPrimaService
    {
        Task<RetornoRequisicao<StringPrima>> ValidarStringPrima(ValidarStringPrimaDto entrada);
    }
}
