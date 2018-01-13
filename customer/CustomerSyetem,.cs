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
        private LogIn LoGin;
        private string uid;
        public CustomerSystem()
        {
            db = new DateBase();
            InitializeComponent();
            db.SortWithCount(listView1);
            uid = "";
            rate = 0;
        }
        public CustomerSystem(LogIn login,string id)
        {
            LoGin = new LogIn();
            LoGin = login;
            db = new DateBase();
            InitializeComponent();
            db.SortWithCount(listView1);
            customer = new Customer(id);
            uid = id;
            rate = 0;
        }
        public string UID()
        {
            return uid;
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
            customer = new Customer();
            foreach (ListViewItem var in listView1.Items)
            {
                if (var.Selected)
                {
                    customer.SetPoint(var.SubItems[0].Text, rate);
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
