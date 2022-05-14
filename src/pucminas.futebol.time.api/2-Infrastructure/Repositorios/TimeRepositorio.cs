using Microsoft.Extensions.Options;
using pucminas.futebol.microservices.core.Base;
using pucminas.futebol.microservices.core.ModelOptions;
using pucminas.futebol.time.api._3_Domian.Entidades;

namespace pucminas.futebol.time.api._2_Infrastructure.Repositorios
{
    public class TimeRepositorio : Repositorio<Time>, ITimeRepositorio
    {
        public TimeRepositorio(IOptions<MongoDbConnection> options) : base(options) { }
    }
}
