using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GrpcService1.Contracts
{
    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }

    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }

    [ServiceContract]
    public interface IGreeterService2
    {
        [OperationContract]
        Task<HelloReply> SayHelloAsync(HelloRequest request,
            CallContext context = default);
    }
}
