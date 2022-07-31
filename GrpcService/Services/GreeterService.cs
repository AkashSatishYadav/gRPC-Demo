using Grpc.Core;
using GrpcService;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<RentReply> AskForRent(RentRequest request, ServerCallContext context)
        {
            RentReply reply;
            if(request.Message == "Give me rent")
            {
                reply = new RentReply
                {
                    Message = "You will get your rent when you fixed this damn door!"
                };
            }
            else
            {
                reply = new RentReply
                {
                    Message = "Here is your rent"
                };
            }
            return Task.FromResult(reply);
        }

    }
}