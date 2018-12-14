using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Shared.Queue
{
    public static class QueueHelpers
    {
        public static async Task EnsureQueueCreatedAsync(string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(Configs.ConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            await queue.CreateIfNotExistsAsync();
        }

        public static CloudQueue GetQueue(string queueName)
        {
            var storageAccount = CloudStorageAccount.Parse(Configs.ConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference(queueName);

            return queue;
        }
    }
}