﻿using Nilvera.Application.Repository;
using RabbitMQ.Client;

namespace Nilvera.Persistence.Repository
{
    public class RabbitMqConnection : IRabbitMqConnection, IDisposable
    {
        private IConnection _connection;
        public IConnection Connection => _connection;

        public RabbitMqConnection()
        {
            InitializeConnection();
        }

        private async void InitializeConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "myrabbitmq"
            };
            _connection = await factory.CreateConnectionAsync();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
