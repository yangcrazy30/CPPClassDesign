using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class LogIn : Form
    {
        private DateBase db;
        private string type;
        private string Uid;
        public LogIn()
        {
            InitializeComponent();
            db = new DateBase();
            type = "0";
            Uid = "";
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            if(db.GetPassword(textBox1.Text,type)==textBox2.Text)
            {
                if(radioButton1.Checked)
                {
                    MenuCreate man = new MenuCreate(this);
                    this.Hide();
                    man.ShowDialog();
                    
                }
                if (radioButton2.Checked)
                {
                    WaiterSystem waiter = new WaiterSystem(this);
                    this.Hide();
                    waiter.ShowDialog();
                 
                }
                if (radioButton3.Checked)
                {
                    Uid = textBox1.Text;
                    CustomerSystem customer = new CustomerSystem(this,Uid);
                    this.Hide();
                    customer.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        private void SigninButton_Click_1(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            this.Hide();
            signup.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "1";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "2";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            type = "3";
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
