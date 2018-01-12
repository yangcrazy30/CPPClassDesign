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
            //menu = db.GetFoodProperty();
        }
        /*public ListViewItem Show()//wrong
        {
           // return db.GetFoodProperty();
        }*/
        public ListViewItem GetOrder(string id)
        {
            order = new ListViewItem();
            order = db.GetOrder(id);
            return order;
        }
        public ListViewItem InsertOrder(ListView listview1, ListView listview2, int num,string UID)
        {
            time = DateTime.Now.ToString();
            foreach (ListViewItem var in listview1.Items)
            {
                order = new ListViewItem();
                if (var.Selected)
                {
                    foreach(ListViewItem item in listview2.Items)
                    {
                        if(item.SubItems[0].Text!=null&&var.SubItems[1].Text==item.SubItems[1].Text)
                        {
                            int result;
                            int.TryParse(item.SubItems[3].Text, out result);
                            result += num;
                            item.SubItems[3].Text = result.ToString();
                            order.SubItems[0].Text = "#";
                        }
                        else
                        {
                            menu = var;
                            db.InsertOrder(UID, menu.SubItems[1].Text, num, menu.SubItems[2].Text, time);
                            order = db.GetOrder(UID);
                        }
                    }
                }
             
            }
            if (order.SubItems[0].Text == ""&&order.SubItems[0].Text!="#")
            {
                MessageBox.Show("请选择下单菜品");
                listview2.Items.Clear();
                return order;
            }
            else
            {
                foreach(ListViewItem var in listview2.Items)
                {
                    if (var.SubItems[0].Text == "")
                        var.Remove();
                }
                return order;
            }
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
