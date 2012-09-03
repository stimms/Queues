using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class WorkItem
    {
        public int ItemID { get; set; }
        public WorkItem()
        {
        }

        public WorkItem(int itemID)
        {
            ItemID = itemID;
        }
    }
}
