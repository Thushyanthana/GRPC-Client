using Grpc.Net.Client;
using System;
using System.Net.Http;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            string customerType = "DIAMOND";
            var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new CalculateDiscountAmount.CalculateDiscountAmountClient(channel);
            var request = new CalculateRequest { Customertype = customerType };
            var reply = client.AmountCalculate(request);

            Console.WriteLine($"Discount for customer type {customerType}  is {(reply.Customerdiscount)}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
