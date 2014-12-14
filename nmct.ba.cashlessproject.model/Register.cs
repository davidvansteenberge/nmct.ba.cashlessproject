using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Register
    {
        #region fields
        private int _id;
        private string _registerName;
        private string _device;
        private string _purchaseDate;
        private string _expiresDate;
        #endregion fields

        #region properties
        public int Id
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string RegisterName
        {
            get { return _registerName; }
            set { if (_registerName != value) { _registerName = value; } }
        }
        public string Device
        {
            get { return _device; }
            set { if (_device != value) { _device = value; } }
        }
        public string PurchaseDate
        {
            get { return _purchaseDate; }
            set { if (_purchaseDate != value) { _purchaseDate = value; } }
        }
        public string ExpiresDate
        {
            get { return _expiresDate; }
            set { if (_expiresDate != value) { _expiresDate = value; } }
        }
        #endregion properties

        #region consturctors
        public Register()
        {

        }
        #endregion constructors
    }
}
