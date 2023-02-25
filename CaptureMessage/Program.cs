using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CaptureMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://hxlbuuxg:2PKW_2gCfkHNT8-IxAVDWfVpInGthCte@rattlesnake.rmq.cloudamqp.com/hxlbuuxg")
            };
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk", true, false, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume("mesaj-kuyruk", true, consumer);
            consumer.Received += Consumer_Received;
            Console.ReadLine();
        }
        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Gelen Mesaj: " + Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}