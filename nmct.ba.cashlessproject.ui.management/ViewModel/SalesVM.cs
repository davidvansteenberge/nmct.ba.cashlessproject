﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.ui.management.ViewModel
{
    class SalesVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Sales page"; }
        }

        public SalesVM()
        {
            if (ApplicationVM.token != null)
            {
                //GetCustomers();
            }
        }
    }
}
