using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Transition : IModel
    {
        public int TransitionID;
        public int KeyID;
        public string KeyType;
        public DateTime TranDate;
        public String NewStatus;
        public String Remarks;
    }
}
