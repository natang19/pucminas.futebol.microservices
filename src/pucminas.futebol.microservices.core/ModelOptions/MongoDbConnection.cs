﻿namespace pucminas.futebol.microservices.core.ModelOptions
{
    public class MongoDbConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
