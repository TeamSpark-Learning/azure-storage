using System;
using System.Threading.Tasks;
using Shared;
using Shared.Queue;

namespace Queue.Lab01.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Azure Storage Queue, Lab01 - Consumer ({Configs.PID})");
            
            await QueueHelpers.EnsureQueueCreatedAsync(QueueConst.Lab01QueueName);

            await Task.Factory.StartNew(ReceiveMessage);
            
            Console.WriteLine("Press 'enter' to close the app.");
            Console.ReadLine();
            
            Console.WriteLine("Done!");            
            Console.ResetColor();
        }

        static async Task ReceiveMessage()
        {
            var queue = QueueHelpers.GetQueue(QueueConst.Lab01QueueName);
            
            while (true)
            {
                var message = await queue.GetMessageAsync();
                if (message != null)
                {
                    Console.WriteLine($"Message received! Content: {message.AsString}");
                    await queue.DeleteMessageAsync(message);
                }
                else
                {
                    Console.WriteLine("No messages in the queue.");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
        }
    }
}