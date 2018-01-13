using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Restaurant
{
    class Waiter:Person
    {
        private Order myorder;
        public Order MyOrder
        {
            get
            {
                return myorder;
            }
        }
        private DateBase db;
        public Waiter(string Id,string Pword)
        {
            ID = Id;
            Password = Pword;
            db = new DateBase();
        }
        public Waiter()
        {
            db = new DateBase();
            ID = null;
            Password = null;
            myorder = new Order();
        }
        public void InsertOrder(ListView listview1,ListView listview2,int num,string UID)
        {

            /* ListViewItem listitem = new ListViewItem();
             foreach(ListViewItem var in listview1.Items)
             {
                 if (var.Selected)
                     listitem = var;
             }
             listview2.Items.Add(listitem);*/
             //db.InsertOrder(listitem.SubItems[0].Text, listitem.SubItems[1].Text, num, listitem.SubItems[2].Text, time);
             
            MyOrder.InsertOrder(listview1, listview2, num, UID);
        }
        public void DeleteinOrder(ListView listview)
        {
            /* ListViewItem temp = new ListViewItem();
             foreach (ListViewItem var in listview.Items)
             {
                 if (var.Selected)
                 {
                     temp = var;
                     var.Remove();
                 }
             }*/
            MyOrder.DeleteOrder(listview);
        }
    }
}
