using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Processador_Votos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();
            
            await channel.QueueDeclareAsync(queue: "votos",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] recebido 1 voto em {0}", message);
                await Task.Yield();
            };

           await channel.BasicConsumeAsync(queue: "votos",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Pressione [enter] para sair.");
            Console.ReadLine();
        
        }
    }
}

