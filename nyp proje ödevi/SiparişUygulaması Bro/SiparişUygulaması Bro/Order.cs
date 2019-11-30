using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparişUygulaması_Bro
{
    class Order
    {
        public string date;
        public string status;
        public Item ıtem = new Item();
        public OrderDetail detail=new OrderDetail();
        public Check check = new Check();
        public Cash cash = new Cash();
        public Credit credit = new Credit();
        public Customer customer = new Customer();

        
        
       
       public int calcTax(int a)
        {
            int Tax = 0;

            Tax = a * 18 / 100;  //Fiyatının %18'i Vergidir.

            return Tax;
        }

       public int calcTotal()
        {
            OrderDetail Detail = new OrderDetail();
           int Total = 0;
            Total = Detail.calcSubTotal()*Detail.quantity+5;
            return Total;
        }

      public  int calcTotalWeight()
        {
            OrderDetail Detail = new OrderDetail();
            int TWeight = 0;
            TWeight = Detail.calcWeight()*Detail.quantity;
            return TWeight;
        }

       

    }
}
