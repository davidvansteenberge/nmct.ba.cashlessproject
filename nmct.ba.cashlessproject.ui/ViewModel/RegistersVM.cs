using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.ui.ViewModel
{
    class RegistersVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Customer page"; }
        }

        public RegistersVM()
        {
            if (ApplicationVM.token != null)
            {
                //GetCustomers();
            }
        }
    }
}
