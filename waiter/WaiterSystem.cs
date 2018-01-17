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
        public LogIn log;
        private int num;
        public int Num
        {
            set { num = value; }
        }
        public WaiterSystem()
        {
            InitializeComponent();
            waiter = new Waiter();
            ListViewItem list2 = waiter.MyOrder.GetOrder(textBox1.Text);
            listView2.Items.Add(list2);
            waiter.MyOrder.GetMenu(listView1);
            

        }
        public WaiterSystem(LogIn login)
        {
            InitializeComponent();
            log = login;
            waiter = new Waiter();
            ListViewItem list2 = waiter.MyOrder.GetOrder(textBox1.Text);
            if (list2.SubItems[0].Text != "") {listView2.Items.Add(list2); }
            waiter.MyOrder.GetMenu(listView1);
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
        private int GetCount()
        {
            int count = 0;
            foreach(ListViewItem var in listView2.Items)
            {
                count += int.Parse(var.SubItems[3].Text);
            }
            return count;
        }
        private void InSertButton_Click(object sender, EventArgs e)
        {
            int count=0;
            listView2.Items.Clear();
            foreach (ListViewItem var in listView1.Items)
            {
                if (var.Selected)
                    count += 1;
            }
            if (count == 1)
            {
                InsertFoodNum isys = new InsertFoodNum(this);
                isys.ShowDialog();
                waiter.MyOrder.InsertOrder(listView1, listView2, num, textBox2.Text);
            }
            else
            {
                MessageBox.Show("请选择菜品");
            }
            float Count;
            float Fprice;
            float Sum = 0;
            foreach (ListViewItem var in listView2.Items)
            {
                float.TryParse(var.SubItems[2].Text, out Fprice);
                float.TryParse(var.SubItems[3].Text, out Count);
                Sum += Count * Fprice;
            }
            textBox1.Text = Sum.ToString();
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
            log.textBox1.Text = "";
            log.textBox2.Text = "";
            log.Show();
        }
    }
}
