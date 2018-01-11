using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    
    public partial class WaiterSystem : Form
    {
        private Order CustomerOrder;
        private int num;
        public int Num
        {
            set { num = value; }
        }
        public WaiterSystem()
        {
            InitializeComponent();
            CustomerOrder = new Order();
            ListViewItem list = CustomerOrder.Show();
            listView1.Items.Add(list);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            float Count;
            float Fprice;
            float Sum=0;
            foreach(ListViewItem var in listView2.Items)
            {
                float.TryParse(var.SubItems[2].Text, out Fprice);
                float.TryParse(var.SubItems[3].Text, out Count);
                Sum += Count * Fprice;
            }
            textBox1.Text = Sum.ToString();
        }

        private void InSertButton_Click(object sender, EventArgs e)
        {
            InsertFoodNum isys = new InsertFoodNum(this);
            isys.ShowDialog();
           listView2.Items.Add( CustomerOrder.InsertOrder(listView1, listView2, num, textBox2.Text));
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            CustomerOrder = new Order();
            CustomerOrder.DeleteOrder(listView2);
        }
    }
}
