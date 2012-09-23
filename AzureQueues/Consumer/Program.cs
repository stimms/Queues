using System;
using System.Linq;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using Microsoft.WindowsAzure.StorageClient;

namespace Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=prdc;AccountKey=6mEliBWPnykttQyZsLS9JJIY4xYNWMXLt3AFsH7FIRnkxLjAPkXQk2kvM/uiQnSidRUvY7DdA2OnW8AFRh0scA==");

            var queueClient = account.CreateCloudQueueClient();
            var queue = queueClient.GetQueueReference("prdc");
            queue.CreateIfNotExist();
            while(true)
            {
                var message = queue.GetMessage();
                if (message != null)
                {
                    Console.WriteLine(message.AsString);
                    queue.DeleteMessage(message);
                }
            }
         
        }
    }
}
