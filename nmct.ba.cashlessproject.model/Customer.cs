using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Customer
    {
        #region fields
        private int _id;
        private string _customerName;
        private string _address;
        private byte[] _picture;
        private double _balance;
        #endregion fields

        #region properties
        public int ID
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { if (_customerName != value) { _customerName = value; } }
        }
        public string Address
        {
            get { return _address; }
            set { if (_address != value) { _address = value; } }
        }
        public byte[] Picture
        {
            get { return _picture; }
            set { if (_picture != value) { _picture = value; } }
        }
        public double Balance
        {
            get { return _balance; }
            set { if (_balance != value) { _balance = value; } }
        }
        #endregion properties

        #region constructor
        public Customer()
        {

        }
        #endregion constructor
    }
}
