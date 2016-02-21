using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Inventory : IModel 
    {
        public int InventoryID;
        public int RawMaterialID;
        public int EmployeeID;
        public int Quantity;
        public DateTime TrDate;
        public string Remarks;
        public int GRNID;
    }
}
