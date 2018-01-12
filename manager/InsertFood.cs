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
            ma = new Manager();
          menucreate.listView1.Items.Add( ma.InsertMenu(textBox1.Text, textBox2.Text, textBox3.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
