using System;
using Common;
using System.Linq;
using System.Messaging;
using System.Collections.Generic;

namespace Consumer
{
    class Program
    {
        private const string QUEUE_ADDRESS = @".\private$\prdc";
        static void Main(string[] args)
        {
            Identify();
            MessageQueue queue = CreateQueue();

            while (true)
            {
                var message = queue.Receive();

                if (message != null)
                {
                    var workItem = message.Body as WorkItem;
                    if (workItem != null)
                    {
                        Console.WriteLine("Recieving message {0}", workItem.ItemID);
                    }
                }
            }
        }

        private static void Identify()
        {
            Console.WriteLine("-------------==================CONSUMER==================-------------");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        private static MessageQueue CreateQueue()
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
            var queue = new MessageQueue(QUEUE_ADDRESS);
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(WorkItem) });
            return queue;
        }
    }
}
