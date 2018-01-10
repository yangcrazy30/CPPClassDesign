using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Customer:Person
    {
        private Order order;
        public Customer():base()
        {
            order = new Order();
        }
        public void GetOrder(string id)
        {

        }
        public void SetPoint()
        {

        }
    }
}
