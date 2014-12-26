using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class RegisterEmployee
    {
        #region fields
        private Register _registerID;
        private Employee _employeeID;
        private int _timeFrom;
        private int _timeTill;
        #endregion fields

        #region properties
        public Register RegisterID
        {
            get { return _registerID; }
            set { if (_registerID != value) { _registerID = value; } }
        }
        public Employee EmployeeID
        {
            get { return _employeeID; }
            set { if (_employeeID != value) { _employeeID = value; } }
        }
        public int TimeFrom
        {
            get { return _timeFrom; }
            set { if (_timeFrom != value) { _timeFrom = value; } }
        }
        public int TimeTill
        {
            get { return _timeTill; }
            set { if (_timeTill != value) { _timeTill = value; } }
        }
        #endregion properties

        #region constructor
        public RegisterEmployee()
        {

        }
        #endregion constructor
    }
}
