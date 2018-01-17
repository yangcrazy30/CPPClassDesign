using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Restaurant
{
    class Customer : Person
    {
        DateBase db;
        private Order order;
        public Customer():base()
        {
            order = new Order();
            db = new DateBase();
        }
        public Customer(string id)
        {
            ID = id;
        }
        public void GetOrderByTime(string SearchTime,ListView L)
        {
            db = new DateBase();
            db.GetOrderBytime(SearchTime, L,ID);
        }

        public string SetPoint(string id,int rate )

         {
            double Rate = double.Parse(db.GetPoint(int.Parse(id)));
            int count = db.GetCount(int.Parse(id));
            double currentRate=(Rate * (db.GetCount(int.Parse(id))-1)+rate)/db.GetCount(int.Parse(id));
            db.PointSet(currentRate, int.Parse(id));
            db.UpdateCount(int.Parse(id), count);
            return currentRate.ToString();
        }
    }
}
