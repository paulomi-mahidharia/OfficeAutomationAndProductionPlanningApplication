using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Order : IModel
    {
        public int OrderID;
        public int QuotationID;
        public int ProductID;
        public int Quantity;
        public int Rate;
        public int PONumber;
        public DateTime PODate;
        public DateTime CreateDate;
        public string Status;
        public string StatusRemarks;
        public int EmployeeID;
        public string DeliveryAddress;
        public DateTime DeliveryDate;
        public string AttachPO;
        public string JobPath;
    }
}
