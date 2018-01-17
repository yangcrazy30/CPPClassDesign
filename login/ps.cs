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
    public partial class ps : Form
    {
        private int temp = 0;
        private int flag = 0;
        private Signup Sup;
        private DateBase Db;
        public ps()
        {
            InitializeComponent();
        }
        public ps(Signup sup)
        {
            InitializeComponent();
            Sup = sup;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (temp <= 5)
            {
                if (textBox1.Text != "888")
                {
                    MessageBox.Show("密码错误");
                    temp++;
                }
                else
                {
                    Db = new DateBase();
                    if (Db.GetPassword(textBox1.Text, "1") == null)
                    {
                        if (Sup.textBox1.Text != "" && Sup.textBox2.Text != "")
                        {
                           
                                Db.SetLogin(Sup.textBox1.Text, Sup.textBox2.Text, "1");
                          
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
            else
            {
                MessageBox.Show("注册已被锁定,请联系开发人员");
                this.Close();
                flag = 1;
            }
            
        }
        public int GetFlag()
        {
            return flag;
        }
    }
}
