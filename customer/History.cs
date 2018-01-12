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
    public partial class History : Form
    {
        private CustomerSystem customer_system;
        private string SearchTime;
        DateBase db;
        private Customer user;
        public History()
        {
            user = new Customer();
            db = new DateBase();
            InitializeComponent();
        }
        public History(CustomerSystem temp)
        {
            this.customer_system = temp;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SearchTime = textBox1.Text + '/' + comboBox1.Text + '/' + textBox2.Text;
            user.GetOrderByTime(SearchTime, listView1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
