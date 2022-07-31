// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7127");
var client = new Greeter.GreeterClient(channel);
var reply = await client.AskForRentAsync(
                  new RentRequest { Message = "Give me rent" });
Console.WriteLine("Reply: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
