using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InProcess
{
    class WorkItem
    {
        private int _itemID { get; set; }
        public WorkItem(int itemID)
        {
            _itemID = itemID;
        }

        public override string ToString()
        {
            return String.Format("Item number {0} processed", _itemID);
        }
    }
}
