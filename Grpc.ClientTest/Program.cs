using Grpc.Net.Client;
using GrpcService1.Contracts;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;

namespace Grpc.ClientTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = channel.CreateGrpcService<IGreeterService2>();

            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" });

            Console.WriteLine($"Greeting: {reply.Message}");
        }
    }
}
