using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Simulador_Votos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configura a fábrica de conexão
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };

            // Cria a conexão assíncrona
            await using var connection = await factory.CreateConnectionAsync("SimuladorVotos");

            // Cria o canal assíncrono
            await using var channel = await connection.CreateChannelAsync(); // retorna IAsyncModel

            // Declara a fila de forma assíncrona
            await channel.QueueDeclareAsync(
                queue: "votos",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            string[] participantes = { "Thiago", "Jaqueline" };
            string message = participantes[0];
            var body = Encoding.UTF8.GetBytes(message);
            var properties = new BasicProperties();

            // Publica mensagem de forma assíncrona
            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "votos",
                mandatory: false,
                basicProperties: properties,
                body: body,
                cancellationToken: default);

            Console.WriteLine(" [x] Enviando 1 voto em {0}", message);
            Console.WriteLine(" Pressione [enter] para sair.");
            Console.ReadLine();
        }
    }
}
