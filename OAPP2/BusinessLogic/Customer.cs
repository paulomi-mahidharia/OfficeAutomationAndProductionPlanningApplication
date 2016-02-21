using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Customer : IModel 
    {
        public int CustomerID;
        public string Name;
        public string Email;
        public string Phone;
        public string ContactPerson;
        public string OfficeAddress;
        public string DeliveryAddress;
        public string HeadOffice;
        public string FactoryAddress;
        public string GodownAddress;
        public string OtherAddress;
    }
}
