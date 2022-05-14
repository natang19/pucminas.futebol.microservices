using MediatR;
using pucminas.futebol.jogador.api._3_Domain.Entidades;

namespace pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Queries
{
    public record ObterJogadoresQuerie() : IRequest<IEnumerable<Jogador>>;
}
