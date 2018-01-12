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
        private Waiter waiter;
        private int num;
        public int Num
        {
            set { num = value; }
        }
        public WaiterSystem()
        {
            InitializeComponent();
            waiter = new Waiter();
          //  ListViewItem list = waiter.MyOrder.Show();
           // listView1.Items.Add(list);
            ListViewItem list2 = waiter.MyOrder.GetOrder(textBox1.Text);
            listView2.Items.Add(list2);

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
           listView2.Items.Add( waiter.MyOrder.InsertOrder(listView1, listView2, num, textBox2.Text));
            foreach(ListViewItem var in listView2.Items)
            {
                if(var.SubItems[0].Text=="#")
                {
                    var.Remove();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            
            waiter.MyOrder.DeleteOrder(listView2);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListViewItem list2 = waiter.MyOrder.GetOrder(textBox2.Text);
            listView2.Items.Add(list2);
            foreach (ListViewItem var in listView2.Items)
            {
                if (var.SubItems[0].Text == "")
                    var.Remove();
            }
        }
    }
}
