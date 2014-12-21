﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Sale
    {
        #region fields
        private int _id;
        private string _timestamp;
        private Customer _customerID;
        private Register _registerID;
        private Product _productID;
        private int _ammount;
        private double _totalPrice;
        #endregion fields

        #region properties
        public int ID
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string Timestamp
        {
            get { return _timestamp; }
            set { if (_timestamp != value) { _timestamp = value; } }
        }
        public Customer CustomerID
        {
            get { return _customerID; }
            set { if (_customerID != value) { _customerID = value; } }
        }
        public Register RegisterID
        {
            get { return _registerID; }
            set { if (_registerID != value) { _registerID = value; } }
        }
        public Product  ProductID
        {
            get { return _productID; }
            set { if (_productID != value) { _productID = value; } }
        }
         public int  Ammount
        {
            get { return _ammount; }
            set { if (_ammount != value) { _ammount = value; } }
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