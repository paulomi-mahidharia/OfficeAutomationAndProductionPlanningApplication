using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class RawMaterial : IModel
    {
        public int RawMaterialID;
        public string Name;
        public int Code;
        public string Descrition;
        public string Unit;
        public int MinQuantity;
        public string Category;
        public int SupplierID;
        public string Type;
    }
}
