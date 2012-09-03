using System;
using Common;
using System.Linq;
using System.Messaging;
using System.Collections.Generic;

namespace MSMQ
{
    class Program
    {
        private const string QUEUE_ADDRESS = @".\private$\prdc";
        static void Main(string[] args)
        {
            Console.WriteLine("-------------==================CONSUMER==================-------------");
            CreateQueue();
            var queue = new MessageQueue(QUEUE_ADDRESS);
            queue.Formatter = new XmlMessageFormatter();

            int id = 0;
            while (true)
            {
                Console.ReadKey();
                queue.Send(new WorkItem(++id));
                Console.WriteLine("Sending message with ID: {0}", id);
            }
        }

        private static void CreateQueue()
        {
            if (!MessageQueue.Exists(QUEUE_ADDRESS))
            {
                try
                {
                    MessageQueue.Create(QUEUE_ADDRESS);
                }
                catch (Exception)
                {
                    Console.WriteLine("Queue creation failure. Often this will happen if two processes rush to create a queue at the same time(race condition) it can largely be ignored");
                }
            }
        }
    }
}
