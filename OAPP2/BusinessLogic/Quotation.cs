using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Quotation : IModel
    {
        public int QuotationID;
        public int ProductID;
        public int MOQ;
        public int Rate;
        public DateTime CreateDate;
        public string Status;
        public string Remarks;
        public string TermsConditions;
        public int EmployeeID;
        public string QuotationPath;
    }
}
