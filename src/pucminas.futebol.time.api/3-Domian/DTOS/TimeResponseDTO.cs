namespace pucminas.futebol.time.api._3_Domian.DTOS
{
    public record TimeResponseDTO : TimeDTO 
    {
        public string Id { get; set; }
        public string DataCadastro { get; set; }
    }
}
