using System;
using System.Text;
using RabbitMQ.Client;

namespace SendMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                SendMessage();
            }
        }

        public static void SendMessage()
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqps://hxlbuuxg:2PKW_2gCfkHNT8-IxAVDWfVpInGthCte@rattlesnake.rmq.cloudamqp.com/hxlbuuxg")
            };
            using var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare("mesaj-kuyruk", true, false, false);
            var mesaj = "Bu bir test mesajıdır";
            var body = Encoding.UTF8.GetBytes(mesaj);
            channel.BasicPublish(String.Empty, "mesaj-kuyruk", null, body);
            Console.WriteLine(mesaj);
            Console.ReadLine();
        }
    }
}