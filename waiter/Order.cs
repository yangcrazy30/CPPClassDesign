using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Restaurant
{
    class Order
    {
        private ListViewItem order;
        private ListViewItem menu;
        private string time;
        private DateBase db;
        public ListViewItem GetOrder()
        {
            return order;
        }
        public Order()
        {
            db = new DateBase();
            order = new ListViewItem();
            menu = new ListViewItem();
            menu = db.GetFoodProperty();
        }
        public ListViewItem Show()//wrong
        {
            return db.GetFoodProperty();
        }
        public ListViewItem InsertOrder(ListView listview1, ListView listview2, int num,string UID)
        {
            time = DateTime.Now.ToString();
            foreach (ListViewItem var in listview1.Items)
            {
                order = new ListViewItem();
                if (var.Selected)
                {
                    menu = var;
                    db.InsertOrder(UID, menu.SubItems[1].Text, num, menu.SubItems[2].Text, time);
                    order = db.GetOrder(UID);
                }

            }
            return order;
        }
        public void DeleteOrder(ListView listview)
        {
            ListViewItem temp = new ListViewItem();
            foreach (ListViewItem var in listview.Items)
            {
                if (var.Selected)
                {
                    temp = var;
                    var.Remove();
                }
                db.DeleteOrder(temp.SubItems[0].Text);
            }
        }
    }
    
}
