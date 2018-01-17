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
    public partial class Signup : Form
    {
        private DateBase db;
        private string type;
        private LogIn log;
        private int flag=0;
        public Signup()
        {
            InitializeComponent();
            db = new DateBase();
            type = "0";
        }
        public Signup(LogIn login)
        {
            InitializeComponent();
            db = new DateBase();
            type = "0";
            log = login;
        }
        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if(radioButton1.Checked)
            {
                ps Ps = new ps();
                if(Ps.GetFlag()==0)
                {
                     Ps.Show();
                }
                else
                {
                    MessageBox.Show("已被锁定无法注册");
                    this.Close();
                }
               
            }
            if (radioButton2.Checked || radioButton3.Checked)
            {
                if (db.GetPassword(textBox1.Text, type) == null)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        if (type != "0")
                        {
                            db.SetLogin(textBox1.Text, textBox2.Text, type);
                            MessageBox.Show("注册成功");
                        }
                        else
                            MessageBox.Show("请选择用户类型");
                    }
                    else
                    {
                        MessageBox.Show("密码或用户名不能为空");
                    }
                }
                else
                {
                    MessageBox.Show("用户名已存在");
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            log.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "3";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            type = "2";
        }
    }
}
