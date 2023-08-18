using Grpc.Core;
using static GrpcServiceServerStreaming.Message;

namespace GrpcServiceServerStreaming.Services
{
    public class MessageService : MessageBase
    {
        public override async Task GetMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"Mesaj alınmıştır.");
            Console.WriteLine("Gelen mesaj : ");
            Console.WriteLine(request.Message);

            await Task.Run(async () =>
            {
                int count = 0;
                while (++count <= 10)
                {
                    await responseStream.WriteAsync(new MessageResponse { Message = $"Gönderilen mesaj {count}" });
                    await Task.Delay(1000);

                }
            });
        }
    }
}
