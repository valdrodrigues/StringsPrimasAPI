using System.Net;

namespace TesteExercicioDois.Domain.Util
{
    public class RetornoRequisicao<T>
    {
        public T Objeto { get; set; }
        public HttpStatusCode Status { get; set; }
        public string Mensagem { get; set; }

        public RetornoRequisicao()
        {
            Status = HttpStatusCode.OK;
            Mensagem = "";
        }

        public RetornoRequisicao(T obj) => Objeto = obj;
    }
}
