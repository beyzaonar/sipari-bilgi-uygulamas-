using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparişUygulaması_Bro
{
    class OrderDetail
    {
        public int quantity=0;
        public int taxStatus;
        Item ıtem;

        public int calcSubTotal()
        {
            Item ıtemx = new Item();
            int SubTotal = 0;
            SubTotal = ıtemx.cost;
            return SubTotal;
        }

        public int calcWeight()
        {
            Item ıtemx = new Item();
            int Weight = 0;
            Weight = ıtemx.getWeight();
            return Weight;
        }
    }
}
