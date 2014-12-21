using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.ui.management.ViewModel
{
    class ProductsVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Products page"; }
        }

        public ProductsVM()
        {
            if (ApplicationVM.token != null)
            {
                //GetProducts();
            }
        }
    }
}
