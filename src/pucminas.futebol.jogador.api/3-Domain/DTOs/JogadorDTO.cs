namespace pucminas.futebol.jogador.api._3_Domain.DTOs
{
    public record JogadorDTO
    {
        public string Nome { get; init; }
        public string Sobrenome { get; init; }
        public string DataNascimento { get; init; }
        public string Pais { get; init; }
        public string IdTime { get; init; }
    }
}
