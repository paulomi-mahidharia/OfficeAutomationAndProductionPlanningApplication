using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Product : IModel
    {
        public int ProductID;
        public int CustomerID;
        public string Name;
        public string DesignFiles;
        public string Status;
        public string Colors;
        public string Type;
        public DateTime CreateDate;
        public string Size;
        public string Description;
    }
}
