using MediatR;

namespace pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Commands
{
    public record ExcluirJogadorCommand(string Id) : IRequest;
}
