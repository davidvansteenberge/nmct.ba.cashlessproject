using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nmct.ba.cashlessproject.model
{
    public class Product
    {
        #region fields
        private int _id;
        private string _productName;
        private double _price;
        #endregion fields

        #region properties
        public int Id
        {
            get { return _id; }
            set { if (_id != value) { _id = value; } }
        }
        public string ProductName
        {
            get { return _productName; }
            set { if (_productName != value) { _productName = value; } }
        }
        public double Price
        {
            get { return _price; }
            set { if (_price != value) { _price = value; } }
        }
        #endregion properties

        #region constructor
        public Product()
        {

        }
        #endregion constructor
    }
}
