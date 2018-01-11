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
        private DateBase db;
        private string time;
        public Waiter(string Id,string Pword)
        {
            ID = Id;
            Password = Pword;
            db = new DateBase();
            time = DateTime.Now.ToString();
        }
        public void InsertOrder(ListView listview1,ListView listview2,int num)
        {
            
            ListViewItem listitem = new ListViewItem();
            foreach(ListViewItem var in listview1.Items)
            {
                if (var.Selected)
                    listitem = var;
            }
            listview2.Items.Add(listitem);
            db.InsertOrder(listitem.SubItems[0].Text, listitem.SubItems[1].Text, num, listitem.SubItems[2].Text, time);

        }
        public void DeleteinOrder(ListView listview)
        {
            ListViewItem temp = new ListViewItem();
            foreach (ListViewItem var in listview.Items)
            {
                if (var.Selected)
                {
                    temp = var;
                    var.Remove();
                }
            }
        }
    }
}
