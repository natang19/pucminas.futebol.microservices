﻿using MongoDB.Driver;

namespace pucminas.futebol.microservices.core.Base
{
    public interface IRepositorio<TEntidade> where TEntidade : Entidade
    {
        Task<IEnumerable<TEntidade>> Buscar(FilterDefinition<TEntidade> filtro);
        Task<IEnumerable<TEntidade>> Obter();
        Task<TEntidade> Obter(string id);
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(string id);
    }
}
