using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparişUygulaması_Bro
{
    class Item
    {
        public string ShippingWeight;
        public string description;
        public string Name;
        public int cost;
        OrderDetail detail;
        
       
        public int getPriceForQuantity()
        {
            int price = 0, quantity=0;
            quantity = detail.quantity;
            price = cost;

            return price * quantity;
        }
        
        public int getWeight()
        {
            int weight = 0;
            weight = Convert.ToInt32(ShippingWeight);
            return weight;
        }

       

        

    }
}
