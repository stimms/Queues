using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace InProcess
{
    class Consumer
    {
        public void Consume()
        {
            while (true)
            {
                var workItem = Program.WorkItems.Take();
                Thread.Sleep(new TimeSpan(0, 0, 3));
                Console.WriteLine(workItem);
            }
        }
    }
}
