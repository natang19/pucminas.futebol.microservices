using MediatR;
using MongoDB.Driver;
using pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Commands;
using pucminas.futebol.jogador.api._2_Infrastructure.Repositorio;
using pucminas.futebol.jogador.api._3_Domain.Entidades;
using pucminas.futebol.microservices.core.Exceptions;

namespace pucminas.futebol.jogador.api._1_Business.Handlers
{
    public class CommandHandler :
            IRequestHandler<CadastrarJogadorCommand, Jogador>,
            IRequestHandler<AtualizarJogadorCommand, Jogador>,
            IRequestHandler<ExcluirJogadorCommand>
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public CommandHandler(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public async Task<Jogador> Handle(CadastrarJogadorCommand request, CancellationToken cancellationToken)
        {
            var builder = Builders<Jogador>.Filter;
            var filtro = builder.Eq(j => j.Nome, request.Nome) & builder.Eq(j => j.Sobrenome, request.Sobrenome);
            var jogadores = await _jogadorRepositorio.Buscar(filtro);

            if (jogadores.Any())
            {
                throw new BusinessException("Jogador já possui cadastro no sistema!");
            }

            var dataNascimento = Convert.ToDateTime(request.DataNascimento);

            var jogador = new Jogador() { Nome = request.Nome, Sobrenome = request.Sobrenome, Pais = request.Pais, IdTime = request.IdTime, DataNascimento = dataNascimento };

            await _jogadorRepositorio.Adicionar(jogador);

            return jogador;
        }

        public async Task<Jogador> Handle(AtualizarJogadorCommand request, CancellationToken cancellationToken)
        {
            var jogador = await _jogadorRepositorio.Obter(request.JogadorDTO.Id);

            if (jogador is null)
            {
                throw new BusinessException("Erro ao atualizar as informações do jogador");
            }

            jogador.Nome = request.JogadorDTO.Nome;
            jogador.Sobrenome = request.JogadorDTO.Sobrenome;
            jogador.DataNascimento = DateTime.Parse(request.JogadorDTO.DataNascimento);
            jogador.Pais = request.JogadorDTO.Pais;
            jogador.IdTime = request.JogadorDTO.IdTime;

            await _jogadorRepositorio.Atualizar(jogador);

            return jogador;
        }

        public Task<Unit> Handle(ExcluirJogadorCommand request, CancellationToken cancellationToken)
        {
            _jogadorRepositorio.Remover(request.Id);
            return Task.FromResult(new Unit());
        }
    }
}
