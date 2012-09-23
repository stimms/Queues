using System;
using System.Linq;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureQueues
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=prdc;AccountKey=6mEliBWPnykttQyZsLS9JJIY4xYNWMXLt3AFsH7FIRnkxLjAPkXQk2kvM/uiQnSidRUvY7DdA2OnW8AFRh0scA==");

            var queueClient = account.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("prdc");
            queue.CreateIfNotExist();

            int i = 0;
            while (true)
            {
                var message = new CloudQueueMessage("I am message number " + i++);
                queue.AddMessage(message);
                Console.Read();
            }
        }
    }
}
