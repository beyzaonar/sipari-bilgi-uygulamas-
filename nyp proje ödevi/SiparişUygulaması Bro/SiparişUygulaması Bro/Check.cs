using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparişUygulaması_Bro
{
    class Check : Payment
    {
        public string name;
        public string bankID;
        Customer customer;




        public bool authorized(Check a)
        {
            if (name == customer.name)
                return true;
            else
                return false;
        }
    }

    
}
