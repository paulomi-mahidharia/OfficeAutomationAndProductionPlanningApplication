using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
  public  class Invoice : IModel
    {
      public int InvoiceID;
      public int OrderID;
      public string InvoiceNo;
      public DateTime InvoiceDate;
      public float GrandTotal;
      public string InvoicePDF;
    }
}
