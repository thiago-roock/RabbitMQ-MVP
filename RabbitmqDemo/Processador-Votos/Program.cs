using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Processador_Votos
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "votos",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] recebido 1 voto em {0}", message);
            };
            channel.BasicConsume(queue: "votos",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Pressione [enter] para sair.");
            Console.ReadLine();
        
        }
    }
}

