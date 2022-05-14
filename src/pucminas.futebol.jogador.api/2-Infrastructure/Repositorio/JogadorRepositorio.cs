using Microsoft.Extensions.Options;
using pucminas.futebol.jogador.api._3_Domain.Entidades;
using pucminas.futebol.microservices.core.Base;
using pucminas.futebol.microservices.core.ModelOptions;

namespace pucminas.futebol.jogador.api._2_Infrastructure.Repositorio
{
    public class JogadorRepositorio : Repositorio<Jogador>, IJogadorRepositorio
    {
        public JogadorRepositorio(IOptions<MongoDbConnection> options) : base(options) { }
    }
}
