using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Sale
    {
        #region fields
        private int _id;
        private long _timestamp;
        private int _customerID;
        private int _registerID;
        private int _productID;
        private int _amount;
        private double _totalPrice;
        #endregion fields

        #region properties
        public int ID
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public long Timestamp
        {
            get { return _timestamp; }
            set { if (_timestamp != value) { _timestamp = value; } }
        }
        public int CustomerID
        {
            get { return _customerID; }
            set { if (_customerID != value) { _customerID = value; } }
        }
        public int RegisterID
        {
            get { return _registerID; }
            set { if (_registerID != value) { _registerID = value; } }
        }
        public int  ProductID
        {
            get { return _productID; }
            set { if (_productID != value) { _productID = value; } }
        }
         public int  Amount
        {
            get { return _amount; }
            set { if (_amount != value) { _amount = value; } }
        }
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { if (_totalPrice != value) { _totalPrice = value; } }
        }
        #endregion properties

        #region constructor
        public Sale()
        {

        }
        #endregion constructor
    }
}
