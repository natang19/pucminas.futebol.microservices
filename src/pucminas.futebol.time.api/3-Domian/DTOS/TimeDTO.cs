namespace pucminas.futebol.time.api._3_Domian.DTOS
{
    public record TimeDTO
    {
        public string Nome { get; init; }
        public string Cidade { get; init; }
        public string Pais { get; init; }
        public string DataFundacao { get; init; }
    }
}
