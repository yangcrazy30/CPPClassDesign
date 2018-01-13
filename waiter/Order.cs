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
        }
      
        public void GetMenu(ListView list)
        {
            db.GetFoodProperty(list);
        }
        public ListViewItem GetOrder(string id)
        {
            order = new ListViewItem();
            return order;
        }
        public string Gettime()
        {
            time = DateTime.Now.ToString();
            return time;
        }
       public void InsertOrder(ListView listview1, ListView listview2, int num,string UID)
        {
            time = Gettime();
            foreach (ListViewItem var in listview1.Items)
            {
                int count = 0;
                order = new ListViewItem();
                if (var.Selected)
                {
                    if(listview2.Items.Count>0)
                    {
                        foreach(ListViewItem item in listview2.Items)
                        {
                            if(item.SubItems[1].Text==var.SubItems[1].Text)
                            {

                                int temp = int.Parse(item.SubItems[3].Text);
                                temp += num;
                                item.SubItems[3].Text = temp.ToString();
                               
                                int fnum = db.GetCount(var.SubItems[0].Text.ToString());
                                db.UpdateCount(var.SubItems[0].Text,(fnum+num));
                                count = 1;
                            }
                        }
                        if(count==0)
                        {
                            db.InsertOrder(UID, var.SubItems[1].Text, num, var.SubItems[2].Text, time);
                            listview2.Items.Clear();
                            db.GetOrder(UID,listview2);
                        }
                        
                    }
                    else
                    {
                        
                        db.InsertOrder(UID, var.SubItems[1].Text, num, var.SubItems[2].Text, time);
                        db.UpdateCount(var.SubItems[0].Text, db.GetCount(var.SubItems[0].Text) + num);
                        listview2.Items.Clear();
                        db.GetOrder(UID,listview2);
                    }
                }
                

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
