using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparişUygulaması_Bro
{
    class Credit : Payment
    {
        public string number;
        public string type;
        public string expDate;

        public bool authorized(Credit a)
        {
            int lenght = a.number.Length;
            bool confirmed=false;
            if (lenght == 16)
                return confirmed = true;
            else
                return confirmed = false;
                
        }



    }
}
