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
        public LogIn()
        {
            InitializeComponent();
            db = new DateBase();
            type = "0";
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
                    MenuCreate man = new MenuCreate();
                    man.ShowDialog();
                    this.Close();
                }
                if (radioButton2.Checked)
                {
                    WaiterSystem waiter = new WaiterSystem();
                    waiter.ShowDialog();
                    this.Close();
                }
                if (radioButton3.Checked)
                {
                    Form4 customer = new Form4();
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
            signup.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            type = "3";
        }
    }
}
