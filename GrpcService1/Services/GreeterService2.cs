using GrpcService1.Contracts;
using ProtoBuf.Grpc;
using System.Threading.Tasks;

namespace GrpcService1.Services
{
    public class GreeterService2 : IGreeterService2
    {
        public Task<Contracts.HelloReply> SayHelloAsync(Contracts.HelloRequest request, CallContext context = default)
        {
            return Task.FromResult(
                new Contracts.HelloReply
                {
                    Message = $"Hello {request.Name}"
                });
        }
    }
}
