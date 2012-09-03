using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
