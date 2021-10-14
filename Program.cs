using System;
using RabbitMQ.Client;
using System.Text;

namespace RMQ_Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("queueTest",  false, false, false, null);

                string message = "test message";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "queueTest", null, body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine("Any key to exit.");
            Console.ReadLine();
        }
    }
}
