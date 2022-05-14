using pucminas.futebol.microservices.core.Base;

namespace pucminas.futebol.time.api._3_Domian.Entidades
{
    public record Time : Entidade
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public DateTime DataFundacao { get; set; }
    }
}
