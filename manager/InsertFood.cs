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

    public partial class InsertFood : Form
    {
        private Manager ma;
        private MenuCreate menucreate;
        public InsertFood()
        {
            InitializeComponent();
            ma = new Manager();
        }
        public InsertFood(MenuCreate menucreate)
        {
            InitializeComponent();
            this.menucreate = menucreate;
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        //确认添加入数据库并显示
        private void button1_Click(object sender, EventArgs e)
        {
            menucreate.listView1.Items.Clear();
            ma = new Manager();
            int temp = 0;
            foreach(ListViewItem var in menucreate.listView1.Items)
            {
                if (var.SubItems[1].Text == textBox2.Text)
                    temp = 1;
            }
            if (temp == 0)
            {
                ma.InsertMenu(textBox2.Text, textBox3.Text,menucreate.listView1);
                MessageBox.Show("添加成功");
            }
            else
                MessageBox.Show("已存在相同菜品");
            this.Close();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
