using MediatR;
using pucminas.futebol.jogador.api._3_Domain.Entidades;

namespace pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Commands
{
    public record CadastrarJogadorCommand(string Nome, string Sobrenome, string DataNascimento, string Pais, string IdTime) : IRequest<Jogador>;
}
