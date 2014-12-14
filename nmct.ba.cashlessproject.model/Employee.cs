using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Employee
    {
        #region fields
        private int _id;
        private string _employeeName;
        private string _address;
        private string _email;
        private string _phone;
        #endregion fields

        #region properties
        public int Id
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string EmployeeName
        {
            get { return _employeeName; }
            set { if (_employeeName != value) { _employeeName = value; } }
        }
        public string Address
        {
            get { return _address; }
            set { if (_address != value) { _address = value; } }
        }
        public string Email
        {
            get { return _email; }
            set { if (_email != value) { _email = value; } }
        }
        public string Phone
        {
            get { return _phone; }
            set { if (_phone != value) { _phone = value; } }
        }
        #endregion properties

        #region constructor
        public Employee()
        {

        }
        #endregion constructor
    }
}
