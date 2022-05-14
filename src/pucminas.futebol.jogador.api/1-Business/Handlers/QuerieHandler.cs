using MediatR;
using pucminas.futebol.jogador.api._2_Infrastructure.CQRS.Queries;
using pucminas.futebol.jogador.api._2_Infrastructure.Repositorio;
using pucminas.futebol.jogador.api._3_Domain.Entidades;

namespace pucminas.futebol.jogador.api._1_Business.Handlers
{
    public class QuerieHandler :
            IRequestHandler<ObterJogadoresQuerie, IEnumerable<Jogador>>,
            IRequestHandler<ObterJogadorPorIdQuerie, Jogador>
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public QuerieHandler(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public Task<IEnumerable<Jogador>> Handle(ObterJogadoresQuerie request, CancellationToken cancellationToken)
        {
            return _jogadorRepositorio.Obter();
        }

        public Task<Jogador> Handle(ObterJogadorPorIdQuerie request, CancellationToken cancellationToken)
        {
            return _jogadorRepositorio.Obter(request.Id);
        }
    }
}
