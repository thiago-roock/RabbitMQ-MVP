using System;
using RabbitMQ.Client;
using System.Text;

namespace Simulador_Votos
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
            string[] participantes = {"Thiago","Jaqueline"};
            string message = $@"{participantes[0]}";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "votos",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] enviando 1 voto em {0}", message);
        

            Console.WriteLine(" Pressione [enter] para sair.");
            Console.ReadLine();
    
        }
    }
}
