using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Restaurant
{
    class Manager:Person
    {
        private Menu menu;
        public Manager():base()
        {
            menu = new Menu();
        }
        public ListViewItem InsertMenu(string id, string name,string price)
        {
           return  menu.Insertfood(id, name, price);
        }
        public void DeletMenu(ListView L)
        {
            menu.Deletefood(L);
        }
    }
}
