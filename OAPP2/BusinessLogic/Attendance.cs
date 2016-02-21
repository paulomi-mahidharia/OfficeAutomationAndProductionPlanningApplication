using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class Attendance : IModel
    {
        public int AttendanceID;
        public int EmployeeID;
        public DateTime Adate;
        public bool Mark;
    }
}
