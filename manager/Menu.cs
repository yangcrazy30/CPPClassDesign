using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Restaurant
{
    class Menu
    {
        private DateBase db;
        public Menu()
        {
            db = new DateBase();
        }
        private ListViewItem menu; 
        public void GetMenu(ListView list)
        {
            db.GetFoodProperty(list);
            
        }
        public ListViewItem Insertfood(string id, string name, string price)
        {
            menu = new ListViewItem();
            menu.SubItems[0].Text = id;
            menu.SubItems.Add(name);
            menu.SubItems.Add(price);
            db.InsertMenu(id, name, price);
            return menu;
        }
        public void Deletefood(ListView L)
        {
            ListViewItem temp = new ListViewItem();
            foreach (ListViewItem var in L.Items)
            {
                if (var.Selected)
                {
                    temp = var;
                    db.DeleteMenu(temp.SubItems[0].Text);
                    var.Remove();
                   
                }
            }
        }

    }
}
