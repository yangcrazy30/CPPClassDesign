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
        public string ID
        {
            get { return ID; }
        }
        public Customer():base()
        {
            order = new Order();
            db = new DateBase();
        }
        public void GetOrderByTime(string SearchTime,ListView L)
        {
            db.GetOrderBytime(SearchTime, L);
        }

        public string SetPoint(string id,int rate )
        {
            double Rate = double.Parse(db.GetPoint(id));
            int count = db.GetCount(id);
            double currentRate=(Rate * (db.GetCount(id)-1)+rate)/db.GetCount(id);
            db.PointSet(currentRate, id);
            db.UpdateCount(id, count);
            return currentRate.ToString();
        }
    }
}
