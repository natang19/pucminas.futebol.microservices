using MediatR;
using pucminas.futebol.jogador.api._3_Domain.DTOs;
using pucminas.futebol.jogador.api._3_Domain.Entidades;

namespace pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Commands
{
    public record AtualizarJogadorCommand(JogadorUpdateDTO JogadorDTO) : IRequest<Jogador>;
}
