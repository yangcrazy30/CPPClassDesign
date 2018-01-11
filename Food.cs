using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Food
    {
        private string foodname;
        public string FoodName
        {
            get
            {
                return foodname;
            }
            set
            {
                foodname = value;
            }
        }
        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        private int ordercount;
        public int OrderCount
        {
            get
            {
                return ordercount;
            }
            set
            {
                ordercount = value;
            }
        }
        private string foodID;
        public string FoodID
        {
            get { return foodID; }
            set
            {
                foodID = value;
            }
        }
    }
}
