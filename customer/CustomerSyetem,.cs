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
    public partial class CustomerSystem : Form
    {
        private int rate;
        private Customer customer;
        DateBase db;
        public CustomerSystem()
        {
            db = new DateBase();
            InitializeComponent();
            db.SortWithCount(listView1);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                rate = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                rate = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
                rate = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
                rate = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
                rate = 5;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem var in listView1.Items)
            {
                if (var.Selected)
                {
                    customer.SetPoint(var.SubItems[0].Text, int.Parse(var.SubItems[3].Text));
                    
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            History getHistory = new History(this);
            getHistory.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
