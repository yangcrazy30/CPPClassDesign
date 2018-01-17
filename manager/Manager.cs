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
        public void InsertMenu(string name,string price,ListView list)
        {
            //menu.Insertfood(name, price);
             menu.Insertfood(name, price,list);
        }
        public void DeletMenu(ListView L)
        {
            menu.Deletefood(L);
        }
    }
}
