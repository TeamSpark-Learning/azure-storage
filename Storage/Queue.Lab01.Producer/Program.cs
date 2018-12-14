using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using Shared;
using Shared.Queue;

namespace Queue.Lab01.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Azure Storage Queue, Lab01 - Producer ({Configs.PID})");
            
            await QueueHelpers.EnsureQueueCreatedAsync(QueueConst.Lab01QueueName);

            var queue = QueueHelpers.GetQueue(QueueConst.Lab01QueueName);

            for (var i = 0; i < QueueConst.Lab01MessagesToSend; i++)
            {
                var obj = new
                {
                    pid = Configs.PID,
                    data = i
                };
                
                var message = new CloudQueueMessage(JsonConvert.SerializeObject(obj));

                Console.WriteLine($"Sending message to queue: {i}");
                
                await queue.AddMessageAsync(message);
            }

            Console.WriteLine("Done!");            
            Console.ResetColor();
        }
    }
}