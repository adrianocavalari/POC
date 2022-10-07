using Grpc.ServiceTest.Contracts;
using ProtoBuf.Grpc;
using System.Threading.Tasks;

namespace Grpc.ServiceTest.Services
{
    public class GreeterServiceCoded : IGreeterServiceCoded
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
