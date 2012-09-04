using System;
using System.Linq;
using System.Collections.Generic;

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
