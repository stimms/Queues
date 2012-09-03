using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InProcess
{
    class Program
    {
        public static BlockingCollection<WorkItem> WorkItems { get; set; }
        static void Main(string[] args)
        {
            WorkItems = new BlockingCollection<WorkItem>();

            var consumers = new List<Consumer>();
            consumers.Add(new Consumer());
            consumers.Add(new Consumer());
            consumers.Add(new Consumer());

            Task.Factory.StartNew(() =>
            {
                consumers.AsParallel().ForAll(x => x.Consume());
            });

            new Producer().Produce();
        }
    }
}
