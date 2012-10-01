using System;
using System.Linq;
using System.Collections.Generic;

namespace InProcess
{
    class Producer
    {
        public void Produce()
        {
            int id = 0;
            while (true)
            {
                id++;
                Console.ReadKey();
                Program.WorkItems.Add(new WorkItem(id));
                Console.WriteLine("Adding item {0} to queue", id);
            }
        }
    }
}
