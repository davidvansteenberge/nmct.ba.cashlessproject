using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.ui.ViewModel
{
    class EmployeesVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Employee page"; }
        }

        public EmployeesVM()
        {
            if (ApplicationVM.token != null)
            {
                //GetCustomers();
            }
        }
    }
}
