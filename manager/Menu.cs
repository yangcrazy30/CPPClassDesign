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
        public void GetMenu(ListView list)
        {
            db.GetFoodProperty(list);
            
        }
        public void Insertfood(string name, string price,ListView list)
        {
            db.InsertMenu(name, price);
            db.GetFoodProperty(list);
        }
        public void Deletefood(ListView L)
        {
            ListViewItem temp = new ListViewItem();
            foreach (ListViewItem var in L.Items)
            {
                if (var.Selected)
                {
                    temp = var;
                    db.DeleteMenu(int.Parse(temp.SubItems[0].Text));
                    var.Remove();
                   
                }
            }
        }

    }
}
